using MasterChef.Domain.Entidades;
using MasterChef.Services;
using Microsoft.AspNetCore.Mvc;

namespace MasterChef.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReceitasController : ControllerBase
    {
        private readonly ReceitaService service = new ReceitaService();

        [HttpGet]
        public ActionResult<ReceitaDTO> GetReceita()
        {
            var result = service.ObterTodos();

            if (result == null)
                return NoContent();

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public ActionResult GetReceita(int id)
        {
            var result = service.Obter(id);

            if (result == null)
                return NoContent();

            return Ok(result);
        }

        [HttpPost]
        public ActionResult PostReceita(ReceitaDTO receita)
        {
            var result = service.Inserir(receita);

            if (result.ID <= 0)
                return NoContent();

            return Created("GetReceita", receita);
        }

        [HttpPut]
        public ActionResult PutReceita(ReceitaDTO receita)
        {
            bool result = service.Atualizar(receita);

            if (result == false)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult DeleteReceita(int id)
        {
            bool result = service.Apagar(id);

            if (result == false)
                return NoContent();

            return Ok(result);
        }
    }
}