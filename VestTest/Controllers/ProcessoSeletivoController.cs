using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class ProcessoSeletivoController : ControllerBase
{
    private readonly VestTestDbContext _context;

    public ProcessoSeletivoController(VestTestDbContext context)
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
        if (processo == null) return NotFound();
        return processo;
    }

    [HttpPost]
    public async Task<ActionResult<ProcessoSeletivo>> Create(ProcessoSeletivo processo)
    {
        _context.ProcessosSeletivos.Add(processo);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = processo.Id }, processo);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ProcessoSeletivo processo)
    {
        if (id != processo.Id) return BadRequest();

        _context.Entry(processo).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var processo = await _context.ProcessosSeletivos.FindAsync(id);
        if (processo == null) return NotFound();

        _context.ProcessosSeletivos.Remove(processo);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
