using Microsoft.AspNetCore.Mvc;
using VestibularApi.API.Requests;
using VestibularApi.API.Responses;
using VestibularApi.Application.Services.Interfaces;

namespace VestibularApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatosController : ControllerBase
    {
        private readonly ICandidatoService _candidatoService;

        public CandidatosController(ICandidatoService candidatoService)
        {
            _candidatoService = candidatoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var candidato = await _candidatoService.ObterPorIdAsync(id);
                return Ok(candidato);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var candidatos = await _candidatoService.ObterTodosAsync();
            return Ok(candidatos);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CandidatoRequest request)
        {
            var candidato = await _candidatoService.CriarAsync(request);
            return CreatedAtAction(nameof(Get), new { id = candidato.Id }, candidato);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CandidatoRequest request)
        {
            try
            {
                await _candidatoService.AtualizarAsync(id, request);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _candidatoService.DeletarAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
