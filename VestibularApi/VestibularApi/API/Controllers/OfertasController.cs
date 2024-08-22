using Microsoft.AspNetCore.Mvc;
using VestibularApi.API.Requests;
using VestibularApi.API.Responses;
using VestibularApi.Application.Services.Interfaces;
using VestibularApi.Domain.Entities;

namespace VestibularApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfertasController : ControllerBase
    {
        private readonly IOfertaService _ofertaService;

        public OfertasController(IOfertaService ofertaService)
        {
            _ofertaService = ofertaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfertaResponse>>> GetAll()
        {
            var ofertas = await _ofertaService.ObterTodasAsync();
            return Ok(ofertas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OfertaResponse>> GetById(Guid id)
        {
            var oferta = await _ofertaService.ObterPorIdAsync(id);

            if (oferta == null)
            {
                return NotFound("Offer not found.");
            }

            return Ok(oferta);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OfertaRequest ofertaRequest)
        {
            if (ofertaRequest == null)
            {
                return BadRequest("Invalid data.");
            }

            var oferta = await _ofertaService.CriarAsync(ofertaRequest);
            return CreatedAtAction(nameof(GetById), new { id = oferta.Id }, oferta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] OfertaRequest ofertaRequest)
        {
            if (ofertaRequest == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                await _ofertaService.AtualizarAsync(id, ofertaRequest);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Offer not found.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _ofertaService.DeletarAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Offer not found.");
            }

            return NoContent();
        }
    }
}
