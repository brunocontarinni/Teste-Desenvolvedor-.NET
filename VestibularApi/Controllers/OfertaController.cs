using Microsoft.AspNetCore.Mvc;
using VestibularApi.Domain.Entities;
using VestibularApi.Infrastructure;

namespace VestibularApi.Controllers
{
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
        public IActionResult GetAll()
        {
            var ofertas = _context.Ofertas.ToList();
            return Ok(ofertas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var oferta = _context.Ofertas.Find(id);

            if(oferta == null)
                return NotFound();

            return Ok(oferta);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Oferta oferta)
        {
            _context.Ofertas.Add(oferta);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = oferta.Id }, oferta);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Oferta updateOferta)
        {
            var oferta = _context.Ofertas.Find(id);
            if (oferta == null)
                return NotFound();

            oferta.Nome = updateOferta.Nome;
            oferta.Descricao = updateOferta.Descricao;
            oferta.VagasDisponiveis = updateOferta.VagasDisponiveis;

            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var oferta = _context.Ofertas.Find(id);
            if (oferta == null)
                return NotFound();

            _context.Ofertas.Remove(oferta);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
