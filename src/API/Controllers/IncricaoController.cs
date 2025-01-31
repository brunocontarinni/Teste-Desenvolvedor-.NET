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
    public class InscricaoController : ControllerBase
    {
        private readonly InscricaoService _service;

        public InscricaoController(InscricaoService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retorna todas as inscrições")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAll();
            return response.Any() ? Ok(response) : NoContent();
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retorna uma inscrições pelo ID")]
        public async Task<IActionResult> GetById(int id)
        {
            var inscricao = await _service.GetById(id);
            return inscricao == null ? NotFound() : Ok(inscricao);
        }

        [HttpGet("cpf/{cpf}")]
        [SwaggerOperation(Summary = "Retorna todas as inscrições buscando por um CPF")]
        public async Task<IActionResult> GetByCpf(string cpf)
        {
            var inscricoes = await _service.GetByCpf(cpf);
            return inscricoes.Any() ? Ok(inscricoes) : NotFound();
        }

        [HttpGet("oferta/{id}")]
        [SwaggerOperation(Summary = "Retorna todas as inscrições buscando por uma oferta")]
        public async Task<IActionResult> GetByIdOfertaAsync(int id)
        {
            var inscricoes = await _service.GetByIdOfertaAsync(id);
            return inscricoes.Any() ? Ok(inscricoes) : NotFound();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Insere uma nova inscrição")]
        public async Task<IActionResult> Create(InscricaoDTO inscricao)
        {
            var response = await _service.Create(inscricao);
            return response != null ? Ok(new { Message = "Criado com sucesso", response.Id }) : NoContent();
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza uma inscrição")]
        public async Task<IActionResult> Update(int id, InscricaoUpdateDTO inscricao)
        {
            var response = await _service.Update(id, inscricao);
            return response ? Ok(new { Message = "Atualizado com sucesso"}) : NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta uma inscrição")]
        public async Task<IActionResult> Delete(int id)
        {
            bool response = await _service.Delete(id);
            return response ? Ok(new { Message = "Excluido com sucesso"}) : NotFound();
        }
    }
}