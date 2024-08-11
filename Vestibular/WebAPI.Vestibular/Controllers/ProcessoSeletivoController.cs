using Infraestrutura.Vestibular.Negocios;
using Microsoft.AspNetCore.Mvc;
using Modelo.Vestibular.Dtos;
using Modelo.Vestibular.ModelView;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Vestibular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessoSeletivoController : ControllerBase
    {
        private readonly ProcessoSeletivoBll _seletivoBll;

        public ProcessoSeletivoController(ProcessoSeletivoBll processo)
        {
            _seletivoBll = processo;
        }

        // GET: api/<ProcessoSeletivoController>
        [HttpGet]
        public async Task<IEnumerable<ProcessoSeletivoDto>> Get()
        {
            return await _seletivoBll.ObterTodos();
        }

        // GET api/<ProcessoSeletivoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProcessoSeletivoDto>> Get(int id)
        {
            try
            {
                return Ok(await _seletivoBll.ObterPorId(id));
            }
            catch (Exception ex) {return BadRequest(ex.Message); }
        }

        // POST api/<ProcessoSeletivoController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromForm] ProcessoSeletivoModelView value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var id = await _seletivoBll.Criar(value);
                    return Ok($"Processo seletivo com id {id}, criada com sucesso.");
                }
                throw new ArgumentException();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProcessoSeletivoController>/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromForm] ProcessoSeletivoModelView value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _seletivoBll.Atualizar(id, value);
                    return Ok($"Processo seletivo com id {id}, atualizada com sucesso.");
                }
                throw new ArgumentException();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<ProcessoSeletivoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _seletivoBll.Apagar(id);
                    return Ok($"Processo seletivo com id {id}, deletado com sucesso.");
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
