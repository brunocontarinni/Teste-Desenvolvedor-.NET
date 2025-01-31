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
    public class OfertaController : ControllerBase
    {
        private readonly OfertaService _service;

        public OfertaController(OfertaService service)
        {
            _service = service;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retorna todas as ofertas")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _service.GetAll();
            return response.Any() ? Ok(response) : NoContent();
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retorna uma oferta pelo ID")]
        public async Task<IActionResult> GetById(int id)
        {
            var oferta = await _service.GetById(id);
            return oferta == null ? NotFound() : Ok(oferta);
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cria uma nova oferta")]
        public async Task<IActionResult> Create(OfertaDTO oferta)
        {
            var response = await _service.Create(oferta);
            return response != null ? Ok(new { Message = "Criado com sucesso", response.Id }) : NoContent();
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Atualiza uma oferta")]
        public async Task<IActionResult> Update(int id, OfertaDTO oferta)
        {
            var response = await _service.Update(id, oferta);
            return response ? Ok(new { Message = "Atualizado com sucesso"}) : NoContent();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta uma oferta")]
        public async Task<IActionResult> Delete(int id)
        {
            bool response = await _service.Delete(id);
            return response ? Ok(new { Message = "Excluido com sucesso"}) : NotFound();
        }
    }
}