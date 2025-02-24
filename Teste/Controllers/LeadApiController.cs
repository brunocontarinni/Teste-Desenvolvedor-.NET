using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste.Models;

namespace Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeadApiController : ControllerBase
    {
        private readonly Contexto _context;

        private readonly ILogger<LeadApiController> _logger;

        public LeadApiController(ILogger<LeadApiController> logger, Contexto context)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/<LeadApiController>
        [HttpGet]
        public async Task<IEnumerable<Lead>> Get()
        {
            return await _context.Leads.ToListAsync();
        }

        // GET api/<LeadApiController>/5
        [HttpGet("{id}")]
        public Task<Lead> Get(int id)
        {
            var lead = _context.Leads.Find(id);
            return Task.FromResult<Lead>(lead);
        }

        // POST api/<LeadApiController>
        [HttpPost]
        public async Task Post([FromBody] Lead value)
        {
            if (ModelState.IsValid)
            {
                _context.Leads.Add(value);
                await _context.SaveChangesAsync();
            }
        }

        // PUT api/<LeadApiController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Lead value)
        {
            if (ModelState.IsValid)
            {
                _context.Leads.Update(value);
                await _context.SaveChangesAsync();
            }
        }

        // DELETE api/<LeadApiController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var lead = await _context.Leads.FindAsync(id);
            if (lead != null)
            {
                _context.Leads.Remove(lead);
            }

            await _context.SaveChangesAsync();
        }
    }
}