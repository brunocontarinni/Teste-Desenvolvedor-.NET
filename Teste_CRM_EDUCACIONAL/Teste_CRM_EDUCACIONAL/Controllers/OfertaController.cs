using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste_CRM_EDUCACIONAL.Data;
using Teste_CRM_EDUCACIONAL.Models;

[ApiController]
[Route("api/[controller]")]
public class OfertaController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public OfertaController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Oferta>>> GetOfertas()
    {
        return await _context.Ofertas.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Oferta>> GetOferta(int id)
    {
        var oferta = await _context.Ofertas.FindAsync(id);

        if (oferta == null)
        {
            return NotFound();
        }

        return oferta;
    }

    [HttpPost]
    public async Task<ActionResult<Oferta>> PostOferta(Oferta oferta)
    {
        _context.Ofertas.Add(oferta);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetOferta), new { id = oferta.Id }, oferta);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutOferta(int id, Oferta oferta)
    {
        if (id != oferta.Id)
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
            if (!OfertaExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return Ok(oferta);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteOferta(int id)
    {
        var oferta = await _context.Ofertas.FindAsync(id);
        if (oferta == null)
        {
            return NotFound();
        }

        _context.Ofertas.Remove(oferta);
        await _context.SaveChangesAsync();

        return Ok("Curso excluído com sucesso!");
    }

    private bool OfertaExists(int id)
    {
        return _context.Ofertas.Any(e => e.Id == id);
    }
}
