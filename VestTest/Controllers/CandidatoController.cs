using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class CandidatoController : ControllerBase
{
    private readonly VestTestDbContext _context;

    public CandidatoController(VestTestDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Candidato>>> GetAll() => await _context.Candidatos.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<Candidato>> GetById(int id)
    {
        var candidato = await _context.Candidatos.FindAsync(id);
        return candidato == null ? NotFound() : candidato;
    }

    [HttpPost]
    public async Task<ActionResult<Candidato>> Create(Candidato candidato)
    {
        _context.Candidatos.Add(candidato);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = candidato.Id }, candidato);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Candidato candidato)
    {
        if (id != candidato.Id) return BadRequest();

        _context.Entry(candidato).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var candidato = await _context.Candidatos.FindAsync(id);
        if (candidato == null) return NotFound();

        _context.Candidatos.Remove(candidato);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
