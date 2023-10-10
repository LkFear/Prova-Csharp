using Microsoft.AspNetCore.Mvc;
using provaLeonardo.Data;
using provaLeonardo.models;

namespace provaLeonardo.Controllers
{
    [ApiController]
    [Route("api/folha")]
    public class FolhaController : ControllerBase
    {

        private readonly AppDataContext _ctx;

        public FolhaController(AppDataContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Folha folha)
        {
            var funcionario = _ctx.Funcionarios.Find(folha.FuncionarioId);
            if (funcionario == null)
            {
                return NotFound();
            }
            folha.Funcionario = funcionario;

            _ctx.Folhas.Add(folha);
            _ctx.SaveChanges();

            return Created("", folha);
        }

        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            try
            {
                var folhas = _ctx.Folhas.ToList();

                foreach (var folha in folhas)
                {
                    folha.Funcionario = _ctx.Funcionarios.Find(folha.FuncionarioId);
                }

                return Ok(folhas);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}