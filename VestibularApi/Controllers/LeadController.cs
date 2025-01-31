using Microsoft.AspNetCore.Mvc;
using VestibularApi.Infrastructure;
using VestibularApi.Domain.Entities;

namespace VestibularApi.Controllers
{
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
        public IActionResult GetAll()
        {
            var leads = _context.Leads.ToList();
            return Ok(leads);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var lead = _context.Leads.Find(id);

            if(lead == null)
                return NotFound();

            return Ok(lead);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Lead lead)
        {
            _context.Leads.Add(lead);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = lead.Id }, lead);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Lead updateLead)
        {
            var lead = _context.Leads.Find(id);
            if (lead == null)
                return NotFound();

            lead.Nome = updateLead.Nome;
            lead.Email = updateLead.Email;
            lead.Telefone = updateLead.Telefone;
            lead.CPF = updateLead.CPF;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var lead = _context.Leads.Find(id);
            if (lead == null)
                return NotFound();

            _context.Leads.Remove(lead);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
