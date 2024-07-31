using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using vestibular_info.Models;
using Vestibular_info.Data;

namespace vestibular_info.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessoSeletivoController : ControllerBase
    {
        private readonly VestibularContext _context;

        public ProcessoSeletivoController(VestibularContext context)
        {
            _context = context;
        }

        // GET: api/ProcessoSeletivo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcessoSeletivo>>> GetProcessosSeletivos()
        {
            return await _context.ProcessosSeletivos.ToListAsync();
        }

        // GET: api/ProcessoSeletivo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProcessoSeletivo>> GetProcessoSeletivo(int id)
        {
            var processoSeletivo = await _context.ProcessosSeletivos.FindAsync(id);

            if (processoSeletivo == null)
            {
                return NotFound();
            }

            return processoSeletivo;
        }

        // PUT: api/ProcessoSeletivo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcessoSeletivo(int id, ProcessoSeletivo processoSeletivo)
        {
            if (id != processoSeletivo.Id)
            {
                return BadRequest();
            }

            _context.Entry(processoSeletivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcessoSeletivoExists(id))
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

        // POST: api/ProcessoSeletivo
        [HttpPost]
        public async Task<ActionResult<ProcessoSeletivo>> PostProcessoSeletivo(ProcessoSeletivo processoSeletivo)
        {
            _context.ProcessosSeletivos.Add(processoSeletivo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProcessoSeletivo", new { id = processoSeletivo.Id }, processoSeletivo);
        }

        // DELETE: api/ProcessoSeletivo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProcessoSeletivo(int id)
        {
            var processoSeletivo = await _context.ProcessosSeletivos.FindAsync(id);
            if (processoSeletivo == null)
            {
                return NotFound();
            }

            _context.ProcessosSeletivos.Remove(processoSeletivo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProcessoSeletivoExists(int id)
        {
            return _context.ProcessosSeletivos.Any(e => e.Id == id);
        }
    }
}
