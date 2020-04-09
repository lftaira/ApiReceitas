using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReceitaDeSucesso.api.Context;

namespace ReceitaDeSucesso.api
{
    public class Startup
    {
        public IConfigurationRoot ConfigurationRoot { get; set; }

        public Startup(IHostEnvironment environment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            ConfigurationRoot = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppConfig>(ConfigurationRoot.GetSection("Config"));

            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddDbContext<ReceitaContext>(builder => builder.UseSqlite(ConfigurationRoot.GetConnectionString("ReceitasContextConStringWinSQLite")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(name: "v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API Receita", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "RECEITA - API V1");
            });
        }
    }
}