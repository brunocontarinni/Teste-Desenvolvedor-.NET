using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste.Models;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscricaoApiController : ControllerBase
    {
        private readonly Contexto _context;

        private readonly ILogger<InscricaoApiController> _logger;

        public InscricaoApiController(ILogger<InscricaoApiController> logger, Contexto context)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/<InscricaoApiController>
        [HttpGet]
        public async Task<IEnumerable<Inscricao>> Get()
        {
            return await _context.Inscricoes.ToListAsync();
        }

        // GET api/<InscricaoApiController>/5
        [HttpGet("{id}")]
        public Task<Inscricao> Get(int id)
        {
            var inscricao = _context.Inscricoes.Find(id);
            return Task.FromResult<Inscricao>(inscricao);
        }

        // GET api/<InscricaoApiController>/5
        [HttpGet("InscricaoPorCPF/{cpf}")]
        public async Task<IEnumerable<Inscricao>> Get(string cpf)
        {
            var listaInscricao = await _context.Inscricoes.ToListAsync();
            var listaFinalInscricaoCPF = listaInscricao.Where(item => item.CPF == cpf);
            return await Task.FromResult(listaFinalInscricaoCPF);
        }

        // POST api/<InscricaoApiController>
        [HttpPost]
        public async Task Post([FromBody] Inscricao value)
        {
            if (ModelState.IsValid)
            {
                _context.Inscricoes.Add(value);
                await _context.SaveChangesAsync();
            }
        }

        // PUT api/<InscricaoApiController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Inscricao value)
        {
            if (ModelState.IsValid)
            {
                _context.Inscricoes.Update(value);
                await _context.SaveChangesAsync();
            }
        }

        // DELETE api/<InscricaoApiController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var inscricao = await _context.Inscricoes.FindAsync(id);
            if (inscricao != null)
            {
                _context.Inscricoes.Remove(inscricao);
            }

            await _context.SaveChangesAsync();
        }
    }
}
