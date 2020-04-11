using MasterChef.Domain.Entidades;
using MasterChef.Services;
using Microsoft.AspNetCore.Mvc;

namespace MasterChef.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly CategoriaService service = new CategoriaService();

        [HttpGet]
        public ActionResult<CategoriaDTO> GetCategoria()
        {
            var result = service.ObterTodos();

            if (result == null)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult GetCategoria(int id)
        {
            var result = service.Obter(id);

            if (result == null)
                return NoContent();

            return Ok(result);
        }

        [HttpPost]
        public ActionResult PostCategoria(CategoriaDTO categoria)
        {
            var result = service.Inserir(categoria);

            if (result.ID <= 0)
                return NoContent();

            return Created("GetCategoria", categoria);
        }

        [HttpPut]
        public ActionResult PutCategoria(CategoriaDTO categoria)
        {
            var result = service.Atualizar(categoria);

            if (result == false)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteCategoria(int id)
        {
            bool result = service.Apagar(id);

            if (result == false)
                return NoContent();

            return Ok(result);
        }
    }
}