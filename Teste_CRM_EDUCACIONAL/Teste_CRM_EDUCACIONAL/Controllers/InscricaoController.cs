using Teste_CRM_EDUCACIONAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste_CRM_EDUCACIONAL.Data;
using Teste_CRM_EDUCACIONAL.DTOs;

namespace Teste_CRM_EDUCACIONAL.Controllers
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
        public async Task<ActionResult<IEnumerable<Inscricao>>> GetInscricoes()
        {
            return await _context.Inscricoes
                .Include(i => i.Lead)
                .Include(i => i.ProcessoSeletivo)
                .Include(i => i.Oferta)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Inscricao>> GetInscricao(int id)
        {
            var inscricao = await _context.Inscricoes
                .Include(i => i.Lead)
                .Include(i => i.ProcessoSeletivo)
                .Include(i => i.Oferta)
                .FirstOrDefaultAsync(i => i.Id == id);

            if (inscricao == null)
            {
                return NotFound();
            }

            return inscricao;
        }

        [HttpGet("ByCpf/{cpf}")]
        public async Task<ActionResult<IEnumerable<Inscricao>>> GetInscricoesByCpf(string cpf)
        {
            var inscricoes = await _context.Inscricoes
                .Include(i => i.Lead)
                .Include(i => i.ProcessoSeletivo)
                .Include(i => i.Oferta)
                .Where(i => i.Lead.CPF == cpf)
                .ToListAsync();

            if (inscricoes == null || !inscricoes.Any())
            {
                return NotFound();
            }

            return inscricoes;
        }

        [HttpGet("ByOferta/{ofertaId}")]
        public async Task<ActionResult<IEnumerable<Inscricao>>> GetInscricoesByOferta(int ofertaId)
        {
            var inscricoes = await _context.Inscricoes
                .Include(i => i.Lead)
                .Include(i => i.ProcessoSeletivo)
                .Include(i => i.Oferta)
                .Where(i => i.OfertaId == ofertaId)
                .ToListAsync();

            if (inscricoes == null || !inscricoes.Any())
            {
                return NotFound();
            }

            return inscricoes;
        }

        [HttpPost]
        public async Task<ActionResult<Inscricao>> PostInscricao(InscricaoDto inscricaoDto)
        {
            var inscricao = new Inscricao
            {
                NumeroDeInscricao = inscricaoDto.NumeroDeInscricao,
                Data = inscricaoDto.Data,
                Status = inscricaoDto.Status,
                LeadId = inscricaoDto.LeadId,
                ProcessoSeletivoId = inscricaoDto.ProcessoSeletivoId,
                OfertaId = inscricaoDto.OfertaId
            };

            _context.Inscricoes.Add(inscricao);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInscricao), new { id = inscricao.Id }, inscricao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscricao(int id, InscricaoDto InscricaoDto)
        {
            if (id != InscricaoDto.Id)
            {
                return BadRequest();
            }

            var inscricao = await _context.Inscricoes.FindAsync(id);
            if (inscricao == null)
            {
                return NotFound();
            }

            inscricao.NumeroDeInscricao = InscricaoDto.NumeroDeInscricao;
            inscricao.Data = InscricaoDto.Data;
            inscricao.Status = InscricaoDto.Status;
            inscricao.LeadId = InscricaoDto.LeadId;
            inscricao.ProcessoSeletivoId = InscricaoDto.ProcessoSeletivoId;
            inscricao.OfertaId = InscricaoDto.OfertaId;

            _context.Entry(inscricao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscricaoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(inscricao);
        }

         [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscricao(int id)
        {
            var inscricao = await _context.Inscricoes.FindAsync(id);
            if (inscricao == null)
            {
                return NotFound();
            }

            _context.Inscricoes.Remove(inscricao);
            await _context.SaveChangesAsync();

            return Ok("Inscrição excluída com sucesso!");
        }

        private bool InscricaoExists(int id)
        {
            return _context.Inscricoes.Any(e => e.Id == id);
        }

    }
}

