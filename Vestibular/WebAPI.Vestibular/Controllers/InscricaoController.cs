using Infraestrutura.Vestibular.Negocios;
using Microsoft.AspNetCore.Mvc;
using Modelo.Vestibular.Dtos;
using Modelo.Vestibular.ModelView;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Vestibular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscricaoController : ControllerBase
    {
        private readonly InscricaoBll _inscricao;

        public InscricaoController(InscricaoBll inscricao)
        {
            _inscricao = inscricao;
        }

        // GET: api/<InscricaoController>
        [HttpGet]
        public async Task<IEnumerable<InscricaoDto>> Get()
        {
            return await _inscricao.ObterTodos();
        }

        // GET api/<InscricaoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InscricaoDto>> Get(int id)
        {
            try
            {
                return Ok(await _inscricao.ObterPorId(id));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }

        // GET api/<InscricaoController>/5
        [HttpGet("CPF/{cpf}")]
        public async Task<ActionResult<IEnumerable<InscricaoDto>>> GetPorCPF([Length(11,11)] string cpf)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    return Ok(await _inscricao.ObterTodosPorCPF(cpf));
                }
                
                throw new NullReferenceException("Por favor, fornecer o CPF.");
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<InscricaoController>/5
        [HttpGet("Oferta/{idOferta}")]
        public async Task<ActionResult<IEnumerable<InscricaoDto>>> GetPorOferta(int idOferta)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    return Ok(await _inscricao.ObterTodosPorOferta(idOferta));
                }

                throw new NullReferenceException("Por favor, fornecer o ID da oferta.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/<InscricaoController>
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromForm] InscricaoModelView value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var id = await _inscricao.Criar(value);
                    return Ok($"Inscrição com id {id}, criada com sucesso.");
                }
                throw new ArgumentException();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<InscricaoController>/5
        [HttpPut("{id}")]
        public ActionResult<string> Put(int id, [FromForm] InscricaoModelView value)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _inscricao.Atualizar(id, value);
                    return Ok($"Inscrição com id {id}, atualizada com sucesso.");
                }
                throw new ArgumentException();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/<InscricaoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> Delete(int id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _inscricao.Apagar(id);
                    return Ok($"Inscrição com id {id}, deletado com sucesso.");
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
