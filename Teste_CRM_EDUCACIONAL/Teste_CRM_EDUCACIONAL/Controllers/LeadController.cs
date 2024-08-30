using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste_CRM_EDUCACIONAL.Data;
using Teste_CRM_EDUCACIONAL.Models;

[ApiController]
[Route("api/[controller]")]
public class LeadController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public LeadController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Lead>>> GetLeads()
    {
        return await _context.Leads.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Lead>> GetLead(int id)
    {
        var lead = await _context.Leads.FindAsync(id);

        if (lead == null)
        {
            return NotFound();
        }

        return lead;
    }

    [HttpPost]
    public async Task<ActionResult<Lead>> PostLead(Lead lead)
        {
        _context.Leads.Add(lead);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetLead), new { id = lead.Id }, lead);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutLead(int id, Lead lead)
    {
        if (id != lead.Id)
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
            if (!LeadExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return Ok(lead);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLead(int id)
    {
        var lead = await _context.Leads.FindAsync(id);
        if (lead == null)
        {
            return NotFound();
        }

        _context.Leads.Remove(lead);
        await _context.SaveChangesAsync();

        return Ok("Candidato excluído com sucesso!");
    }

    private bool LeadExists(int id)
    {
        return _context.Leads.Any(e => e.Id == id);
    }
}
