using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Services;
using Application.DTO;
using System.Linq;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatoController : ControllerBase
    {
        private readonly CandidatoService _service;

        public CandidatoController(CandidatoService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retorna TODOS os candidatos")]
        public async Task<IActionResult> GetAll() 
        {
            var response = await _service.GetAll();
            return response.Any() ? Ok(response) : NoContent();
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retorna um candidato pelo ID")]
        public async Task<IActionResult> GetById(int id)
        {
            var candidato = await _service.GetById(id);
            return candidato == null ? NotFound() : Ok(candidato);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo candidato")]
        public async Task<IActionResult> Create(CandidatoDTO candidato)
        {
            var response = await _service.Create(candidato);
            return response != null ? Ok(new { Message = "Criado com sucesso", response.Id }) : NoContent();
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza o cadastro de um candidato")]
        public async Task<IActionResult> Update(int id, CandidatoDTO candidato)
        {
            var response = await _service.Update(id, candidato);
            return response ? Ok(new { Message = "Atualizado com sucesso"}) : NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta um candidato")]
        public async Task<IActionResult> Delete(int id)
        {
            bool response = await _service.Delete(id);
            return response ? Ok(new { Message = "Excluido com sucesso"}) : NotFound();
        }
    }
}