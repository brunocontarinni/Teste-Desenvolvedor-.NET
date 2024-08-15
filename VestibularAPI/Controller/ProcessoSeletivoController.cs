using Microsoft.AspNetCore.Mvc;
using VestibularAPI.Data;
using VestibularAPI.Models;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class ProcessoSeletivoController : ControllerBase
{
    private readonly VestibularContext _context;

    public ProcessoSeletivoController(VestibularContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProcessoSeletivo>>> GetAll()
    {
        return await _context.ProcessosSeletivos.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProcessoSeletivo>> GetById(int id)
    {
        var processo = await _context.ProcessosSeletivos.FindAsync(id);

        if (processo == null)
        {
            return NotFound();
        }

        return processo;
    }

    [HttpPost]
    public async Task<ActionResult<ProcessoSeletivo>> Create(ProcessoSeletivo processoSeletivo)
    {
        _context.ProcessosSeletivos.Add(processoSeletivo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = processoSeletivo.ID }, processoSeletivo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProcessoSeletivo processoSeletivo)
    {
        if (id != processoSeletivo.ID)
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
            if (!_context.ProcessosSeletivos.Any(e => e.ID == id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
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
}
