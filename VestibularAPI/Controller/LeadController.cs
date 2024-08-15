using Microsoft.AspNetCore.Mvc;
using VestibularAPI.Data;
using VestibularAPI.Models;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class LeadController : ControllerBase
{
    private readonly VestibularContext _context;

    public LeadController(VestibularContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Lead>>> GetAll()
    {
        return await _context.Leads.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Lead>> GetById(int id)
    {
        var processo = await _context.Leads.FindAsync(id);

        if (processo == null)
        {
            return NotFound();
        }

        return processo;
    }

    [HttpPost]
    public async Task<ActionResult<Lead>> Create(Lead lead)
    {
        _context.Leads.Add(lead);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = lead.ID }, lead);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Lead lead)
    {
        if (id != lead.ID)
        {
            return BadRequest();
        }

        _context.Entry(lead).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Leads.Any(e => e.ID == id))
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
        var lead = await _context.Leads.FindAsync(id);

        if (lead == null)
        {
            return NotFound();
        }

        _context.Leads.Remove(lead);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
