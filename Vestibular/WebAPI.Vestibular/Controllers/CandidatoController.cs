using Infraestrutura.Vestibular.Negocios;
using Microsoft.AspNetCore.Mvc;
using Modelo.Vestibular.Dtos;
using Modelo.Vestibular.ModelView;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Vestibular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatoController : ControllerBase
    {
        private readonly CandidatoBll _candidato;

        public CandidatoController(CandidatoBll candidato)
        {
            _candidato = candidato;
        }

        // GET: api/<CandidatoController>
        [HttpGet]
        public async Task<IEnumerable<CandidatoDto>> Get()
        {
            return await _candidato.ObterTodos();
        }

        // GET api/<CandidatoController>/5
        [HttpGet("{id}")]
        public async Task<CandidatoDto> Get(int id)
        {
            return await _candidato.ObterPorId(id);
        }

        // POST api/<CandidatoController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromForm] CandidatoModelView value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var id = await _candidato.Criar(value);
                    return Ok($"Inscrição com id {id}, criada com sucesso.");
                }
                throw new ArgumentException();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<CandidatoController>/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromForm] CandidatoModelView value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _candidato.Atualizar(id, value);
                    return Ok($"Candidato com id {id}, atualizada com sucesso.");
                }
                throw new ArgumentException();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<CandidatoController>/5
        [HttpDelete("{id}")]
        public ActionResult<string> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _candidato.Apagar(id);
                    return Ok($"Candidato com id {id}, deletado com sucesso.");
                }
                throw new ArgumentException();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
