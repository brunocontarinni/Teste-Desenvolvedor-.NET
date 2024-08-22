using Microsoft.AspNetCore.Mvc;
using VestibularApi.API.Requests;
using VestibularApi.API.Responses;
using VestibularApi.Application.Services.Interfaces;

namespace VestibularApi.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessoSeletivoController : ControllerBase
    {
        private readonly IProcessoSeletivoService _processoSeletivoService;

        public ProcessoSeletivoController(IProcessoSeletivoService processoSeletivoService)
        {
            _processoSeletivoService = processoSeletivoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcessoSeletivoResponse>>> GetAll()
        {
            var processos = await _processoSeletivoService.ObterTodosAsync();
            return Ok(processos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProcessoSeletivoResponse>> GetById(Guid id)
        {
            var processoSeletivo = await _processoSeletivoService.ObterPorIdAsync(id);

            if (processoSeletivo == null)
            {
                return NotFound("Processo Seletivo não encontrado.");
            }

            return Ok(processoSeletivo);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProcessoSeletivoRequest processoSeletivoRequest)
        {
            if (processoSeletivoRequest == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var processoSeletivo = await _processoSeletivoService.CriarAsync(processoSeletivoRequest);
            return CreatedAtAction(nameof(GetById), new { id = processoSeletivo.Id }, processoSeletivo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] ProcessoSeletivoRequest processoSeletivoRequest)
        {
            if (processoSeletivoRequest == null)
            {
                return BadRequest("Dados inválidos.");
            }

            try
            {
                await _processoSeletivoService.AtualizarAsync(id, processoSeletivoRequest);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Processo Seletivo não encontrado.");
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _processoSeletivoService.DeletarAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Processo Seletivo não encontrado.");
            }

            return NoContent();
        }
    }
}
