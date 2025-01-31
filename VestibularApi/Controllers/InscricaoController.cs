using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VestibularApi.Domain.Entities;
using VestibularApi.Infrastructure;

namespace VestibularApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InscricaoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public InscricaoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var inscricoes = _context.Inscricoes.ToList();
            return Ok(inscricoes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var inscricao = _context.Inscricoes.Find(id);

            if (inscricao == null)
                return NotFound();

            return Ok(inscricao);
        }

        // Buscar inscrições por CPF
        [HttpGet("cpf/{cpf}")]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
            var inscricoes = await _context.Inscricoes
                .Include(i => i.Lead)
                .Where(i => i.Lead.CPF == cpf)
                .ToListAsync();

            if (inscricoes == null || !inscricoes.Any())
                return NotFound("Nenhuma inscrição encontrada para o CPF informado.");

            return Ok(inscricoes);
        }
        // Buscar inscrições por oferta
        [HttpGet("oferta/{ofertaId}")]
        public async Task<IActionResult> GetByOferta(int ofertaId)
        {
            var inscricoes = await _context.Inscricoes
                .Include(i => i.Oferta)
                .Where(i => i.OfertaId == ofertaId)
                .ToListAsync();

            if (inscricoes == null || !inscricoes.Any())
                return NotFound("Nenhuma inscrição encontrada para a oferta informada.");

            return Ok(inscricoes);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Inscricao inscricao)
        {
            if (_context.Leads.Find(inscricao.LeadId) == null)
            {
                return BadRequest("O LeadId informado não existe.");
            }
            else if (_context.ProcessosSeletivos.Find(inscricao.ProcessoSeletivoId) == null)
            {
                return BadRequest("O ProcessoSeletivoId informado não existe.");
            }
            if (_context.Ofertas.Find(inscricao.OfertaId) == null)
            {
                return BadRequest("O OfertaId informado não existe.");
            }

            _context.Inscricoes.Add(inscricao);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id =  inscricao.Id }, inscricao);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Inscricao updateInscricao)
        {
            var inscricao = _context.Inscricoes.Find(id);
            if(inscricao == null)
                return NotFound();

            inscricao.Status = updateInscricao.Status;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var inscricao = _context.Inscricoes.Find(id);
            if (inscricao == null)
                return NotFound();

            _context.Inscricoes.Remove(inscricao);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
