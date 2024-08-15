using Microsoft.AspNetCore.Mvc;
using VestibularAPI.Data;
using VestibularAPI.Models;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class OfertaController : ControllerBase
{
    private readonly VestibularContext _context;

    public OfertaController(VestibularContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Oferta>>> GetAll()
    {
        return await _context.Ofertas.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Oferta>> GetById(int id)
    {
        var processo = await _context.Ofertas.FindAsync(id);

        if (processo == null)
        {
            return NotFound();
        }

        return processo;
    }

    [HttpPost]
    public async Task<ActionResult<Oferta>> Create(Oferta oferta)
    {
        _context.Ofertas.Add(oferta);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = oferta.ID }, oferta);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Oferta oferta)
    {
        if (id != oferta.ID)
        {
            return BadRequest();
        }

        _context.Entry(oferta).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Ofertas.Any(e => e.ID == id))
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
        var oferta = await _context.Ofertas.FindAsync(id);

        if (oferta == null)
        {
            return NotFound();
        }

        _context.Ofertas.Remove(oferta);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
