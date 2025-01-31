using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

[ApiController]
[Route("api/[controller]")]
public class OfertaCursoController : ControllerBase
{
    private readonly VestTestDbContext _context;

    public OfertaCursoController(VestTestDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<OfertaCurso>>> GetAll() => await _context.OfertaCursos.ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<OfertaCurso>> GetById(int id)
    {
        var oferta = await _context.OfertaCursos.FindAsync(id);
        return oferta == null ? NotFound() : oferta;
    }

    [HttpPost]
    public async Task<ActionResult<OfertaCurso>> Create(OfertaCurso oferta)
    {
        _context.OfertaCursos.Add(oferta);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = oferta.Id }, oferta);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, OfertaCurso oferta)
    {
        if (id != oferta.Id) return BadRequest();

        _context.Entry(oferta).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var oferta = await _context.OfertaCursos.FindAsync(id);
        if (oferta == null) return NotFound();

        _context.OfertaCursos.Remove(oferta);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
