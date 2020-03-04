using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ReceitaDeSucesso.api.Models;

namespace ReceitaDeSucesso.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceitaController : ControllerBase
    {
        private readonly DbContext _dbContext;

        public ReceitaController(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Receita> Receitas()
        {
            return new List<Receita>();
        }

        [HttpPost]
        public StatusCodeResult Receitas(Receita receita)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400);
            }

            _dbContext.Add(receita);
            _dbContext.SaveChanges();
            return StatusCode(201);
        }


    }
}