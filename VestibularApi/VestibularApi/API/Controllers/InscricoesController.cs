using Microsoft.AspNetCore.Mvc;
using VestibularApi.API.Requests;
using VestibularApi.API.Responses;
using VestibularApi.Application.Services.Inscricao;

namespace VestibularApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InscricoesController : ControllerBase
    {
        private readonly IInscricaoService _inscricaoService;

        public InscricoesController(IInscricaoService inscricaoService)
        {
            _inscricaoService = inscricaoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InscricaoResponse>>> GetAll()
        {
            var inscricoes = await _inscricaoService.ObterTodasAsync();
            return Ok(inscricoes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<InscricaoResponse>> GetById(Guid id)
        {
            var inscricao = await _inscricaoService.ObterPorIdAsync(id);

            if (inscricao == null)
            {
                return NotFound("Inscription not found.");
            }

            return Ok(inscricao);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InscricaoRequest inscricaoRequest)
        {
            if (inscricaoRequest == null)
            {
                return BadRequest("Invalid data.");
            }

            var inscricao = await _inscricaoService.CriarAsync(inscricaoRequest);
            return CreatedAtAction(nameof(GetById), new { id = inscricao.Id }, inscricao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] InscricaoRequest inscricaoRequest)
        {
            if (inscricaoRequest == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                await _inscricaoService.AtualizarAsync(id, inscricaoRequest);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Inscription not found.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _inscricaoService.DeletarAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Inscription not found.");
            }

            return NoContent();
        }
    }
}
