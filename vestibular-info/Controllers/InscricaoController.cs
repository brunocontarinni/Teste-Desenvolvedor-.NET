using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vestibular_info.Models;
using Vestibular_info.Data;


namespace vestibular_info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscricaoController : ControllerBase
    {
        private readonly VestibularContext _context;

        public InscricaoController(VestibularContext context)
        {
            _context = context;
        }

        // GET: api/Inscricao
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inscricao>>> GetInscricoes()
        {
            return await _context.Inscricoes.ToListAsync();
        }

        // GET: api/Inscricao/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inscricao>> GetInscricao(int id)
        {
            var inscricao = await _context.Inscricoes.FindAsync(id);

            if (inscricao == null)
            {
                return NotFound();
            }

            return inscricao;
        }

        // PUT: api/Inscricao/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscricao(int id, Inscricao inscricao)
        {
            if (id != inscricao.Id)
            {
                return BadRequest();
            }

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

            return NoContent();
        }

        // POST: api/Inscricao
        [HttpPost]
        public async Task<ActionResult<Inscricao>> PostInscricao(Inscricao inscricao)
        {
            _context.Inscricoes.Add(inscricao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInscricao", new { id = inscricao.Id }, inscricao);
        }

        // DELETE: api/Inscricao/5
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

            return NoContent();
        }

        private bool InscricaoExists(int id)
        {
            return _context.Inscricoes.Any(e => e.Id == id);
        }

        //Get api/Inscricao/ByCPF/{cpf}

        public async Task<ActionResult<IEnumerable<Inscricao>>> GetInscricaoByCPF(string cpf)
        {
            var lead = await _context.Leads.FirstOrDefaultAsync(l => l.CPF == cpf);

            if(lead == null)
            {
                return NotFound( new {message = "CPF não encontrado"});
            }
            var inscricoes = await _context.Inscricoes.Where(i => i.LeadId == lead.Id).ToListAsync();

            if (inscricoes.Count == 0)
            {
                return NotFound(new { message = "Nenhuma inscrição encontrada para este CPF" });
            }

            return inscricoes;
        }

        // GET: api/Inscricao/ByOferta/{id}
        [HttpGet("ByOferta/{id}")]
        public async Task<ActionResult<IEnumerable<Inscricao>>> GetInscricoesByOferta(int id)
        {
            var oferta = await _context.Ofertas.FindAsync(id);

            if (oferta == null)
            {
                return NotFound(new { message = "Oferta não encontrada" });
            }

            var inscricoes = await _context.Inscricoes.Where(i => i.OfertaId == id).ToListAsync();

            if (inscricoes.Count == 0)
            {
                return NotFound(new { message = "Nenhuma inscrição encontrada para esta oferta" });
            }

            return inscricoes;
        }
    }
}
