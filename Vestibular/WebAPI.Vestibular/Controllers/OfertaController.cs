using Infraestrutura.Vestibular.Negocios;
using Microsoft.AspNetCore.Mvc;
using Modelo.Vestibular.Dtos;
using Modelo.Vestibular.ModelView;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Vestibular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertaController : ControllerBase
    {
        private readonly OfertaBll _ofertaBll;
        public OfertaController(OfertaBll bll)
        {
            _ofertaBll = bll;
        }

        // GET: api/<OfertaController>
        [HttpGet]
        public async Task<IEnumerable<OfertaDto>> Get()
        {
            return await _ofertaBll.ObterTodos();
        }

        // GET api/<OfertaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OfertaDto>> Get(int id)
        {
            try
            {
                return Ok(await _ofertaBll.ObterPorId(id));
            }
            catch (Exception ex) {return BadRequest(ex.Message); }
        }

        // POST api/<OfertaController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromForm] OfertaModelView value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var id = await _ofertaBll.Criar(value);
                    return Ok($"Oferta com id {id}, criada com sucesso.");
                }
                throw new ArgumentException();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<OfertaController>/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromForm] OfertaModelView value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _ofertaBll.Atualizar(id, value);
                    return Ok($"Oferta com id {id}, atualizada com sucesso.");
                }
                throw new ArgumentException();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<OfertaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _ofertaBll.Apagar(id);
                    return Ok($"Oferta com id {id}, deletado com sucesso.");
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
