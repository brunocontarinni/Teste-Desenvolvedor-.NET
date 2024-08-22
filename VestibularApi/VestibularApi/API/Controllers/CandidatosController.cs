using Microsoft.AspNetCore.Mvc;
using VestibularApi.API.Requests;
using VestibularApi.API.Responses;
using VestibularApi.Application.Services;
using VestibularApi.Domain.Entities;

namespace VestibularApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatosController : ControllerBase
    {
        private readonly CandidatoService _candidatoService;

        public CandidatosController(CandidatoService candidatoService)
        {
            _candidatoService = candidatoService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var candidato = await _candidatoService.PegarPorIdAsync(id);
            if (candidato == null)
                return NotFound();

            var response = new CandidatoResponse
            {
                Id = candidato.Id,
                Nome = candidato.Nome,
                CPF = candidato.CPF
            };
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var candidatos = await _candidatoService.PegarTodosAsync();
            var response = candidatos.Select(c => new CandidatoResponse
            {
                Id = c.Id,
                Nome = c.Nome,
                CPF = c.CPF,
                DataCriacao = DateTime.UtcNow
            });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CandidatoRequest request)
        {
            var candidato = new Candidato(request.Nome, request.CPF); 
            await _candidatoService.AdicionarAsync(candidato);

            var response = new CandidatoResponse
            {
                Id = candidato.Id,
                Nome = candidato.Nome,
                CPF = candidato.CPF
            };
            return CreatedAtAction(nameof(Get), new { id = candidato.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] CandidatoRequest request)
        {
            var candidato = await _candidatoService.PegarPorIdAsync(id);
            if (candidato == null)
                return NotFound();

            candidato.AlterarNome(request.Nome);
            candidato.AlterarCPF(request.CPF);

            await _candidatoService.AtualizarAsync(candidato);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _candidatoService.DeletarAsync(id);
            return NoContent();
        }
    }
}
