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
    public class ProcessoSeletivoController : ControllerBase
    {
        private readonly ProcessoSeletivoService _service;

        public ProcessoSeletivoController(ProcessoSeletivoService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retorna todos os processos seletivos")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAll();
            return response.Any() ? Ok(response) : NoContent();
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retorna um processo seletivo pelo ID")]
        public async Task<IActionResult> GetById(int id)
        {
            var processoSeletivo = await _service.GetById(id);
            return processoSeletivo == null ? NotFound() : Ok(processoSeletivo);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra um novo processo seletivo")]
        public async Task<IActionResult> Create(ProcessoSeletivoDTO processoSeletivo)
        {
            var response = await _service.Create(processoSeletivo);
            return response != null ? Ok(new { Message = "Criado com sucesso", response.Id }) : NoContent();
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza um processo seletivo")]
        public async Task<IActionResult> Update(int id, ProcessoSeletivoDTO processoSeletivo)
        {
            var response = await _service.Update(id, processoSeletivo);
            return response ? Ok(new { Message = "Atualizado com sucesso"}) : NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta um processo seletivo")]
        public async Task<IActionResult> Delete(int id)
        {
            bool response = await _service.Delete(id);
            return response ? Ok(new { Message = "Excluido com sucesso"}) : NotFound();
        }
    }
}