using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste.Models;

namespace Teste.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertaApiController : ControllerBase
    {
        private readonly Contexto _context;

        private readonly ILogger<OfertaApiController> _logger;

        public OfertaApiController(ILogger<OfertaApiController> logger, Contexto context)
        {
            _context = context;
            _logger = logger;
        }

        // GET: api/<LeadApiController>
        [HttpGet]
        public async Task<IEnumerable<Oferta>> Get()
        {
            return await _context.Ofertas.ToListAsync();
        }

        // GET api/<LeadApiController>/5
        [HttpGet("{id}")]
        public Task<Oferta> Get(int id)
        {
            var lead = _context.Ofertas.Find(id);
            return Task.FromResult<Oferta>(lead);
        }

        // POST api/<LeadApiController>
        [HttpPost]
        public async Task Post([FromBody] Oferta value)
        {
            if (ModelState.IsValid)
            {
                _context.Ofertas.Add(value);
                await _context.SaveChangesAsync();
            }
        }

        // PUT api/<LeadApiController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Oferta value)
        {
            if (ModelState.IsValid)
            {
                _context.Ofertas.Update(value);
                await _context.SaveChangesAsync();
            }
        }

        // DELETE api/<LeadApiController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            var oferta = await _context.Ofertas.FindAsync(id);
            if (oferta != null)
            {
                _context.Ofertas.Remove(oferta);
            }

            await _context.SaveChangesAsync();
        }
    }
}
