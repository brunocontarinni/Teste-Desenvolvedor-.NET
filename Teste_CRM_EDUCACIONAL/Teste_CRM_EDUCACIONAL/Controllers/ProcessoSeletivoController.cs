using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste_CRM_EDUCACIONAL.Data;
using Teste_CRM_EDUCACIONAL.Models;

[ApiController]
[Route("api/[controller]")]
public class ProcessoSeletivoController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public ProcessoSeletivoController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProcessoSeletivo>>> GetProcessosSeletivos()
    {
        return await _context.ProcessosSeletivos.ToListAsync();
    }

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

    [HttpPost]
    public async Task<ActionResult<ProcessoSeletivo>> PostProcessoSeletivo(ProcessoSeletivo processoSeletivo)
    {
        _context.ProcessosSeletivos.Add(processoSeletivo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProcessoSeletivo), new { id = processoSeletivo.Id }, processoSeletivo);
    }

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

        return Ok(processoSeletivo);
    }

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

        return Ok("Processo Seletivo excluído com sucesso!");
    }

    private bool ProcessoSeletivoExists(int id)
    {
        return _context.ProcessosSeletivos.Any(e => e.Id == id);
    }
}
