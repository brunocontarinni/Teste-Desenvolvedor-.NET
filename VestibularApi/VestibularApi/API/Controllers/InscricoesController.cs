using Microsoft.AspNetCore.Mvc;
using VestibularApi.API.Requests;
using VestibularApi.API.Responses;
using VestibularApi.Application.Services.Interfaces;

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
            try
            {
                var inscricao = await _inscricaoService.ObterPorIdAsync(id);
                return Ok(inscricao);
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Inscrição não encontrada.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] InscricaoRequest inscricaoRequest)
        {
            if (inscricaoRequest == null)
            {
                return BadRequest("Dados inválidos.");
            }

            var inscricao = await _inscricaoService.CriarAsync(inscricaoRequest);
            return CreatedAtAction(nameof(GetById), new { id = inscricao.Id }, inscricao);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] InscricaoRequest inscricaoRequest)
        {
            if (inscricaoRequest == null)
            {
                return BadRequest("Dados inválidos.");
            }

            try
            {
                await _inscricaoService.AtualizarAsync(id, inscricaoRequest);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Inscrição não encontrada.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _inscricaoService.DeletarAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound("Inscrição não encontrada.");
            }
        }

        [HttpGet("cpf/{cpf}")]
        public async Task<ActionResult<IEnumerable<InscricaoResponse>>> PegarPorCpf(string cpf)
        {
            var inscricoes = await _inscricaoService.PegarPorCpfAsync(cpf);
            if (inscricoes == null || !inscricoes.Any())
            {
                return NotFound("Nenhuma inscrição encontrada para o CPF informado.");
            }
            return Ok(inscricoes);
        }

        [HttpGet("oferta/{ofertaId}")]
        public async Task<ActionResult<IEnumerable<InscricaoResponse>>> PegarPorOferta(Guid ofertaId)
        {
            var inscricoes = await _inscricaoService.PegarPorOfertaAsync(ofertaId);
            if (inscricoes == null || !inscricoes.Any())
            {
                return NotFound("Nenhuma inscrição encontrada para a oferta informada.");
            }
            return Ok(inscricoes);
        }
    }
}
