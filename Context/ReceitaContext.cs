using Microsoft.EntityFrameworkCore;
using ReceitaDeSucesso.api.Models;

namespace ReceitaDeSucesso.api.Context
{
    public class ReceitaContext : DbContext
    {
        public DbSet<Receita> Receitas { get; set; }

        public ReceitaContext(DbContextOptions<ReceitaContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Receita>()
            .HasOne(x => x.Categoria);
        }
    }
}