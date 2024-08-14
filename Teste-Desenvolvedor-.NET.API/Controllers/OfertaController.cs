using Microsoft.AspNetCore.Mvc;
using Teste_Desenvolvedor_.NET.Models.Models;
using Teste_Desenvolvedor_.NET.Services.Interfaces;

namespace Teste_Desenvolvedor_.NET.API.Controllers
{
    [ApiController]
    [Route("api/v1/oferta")]
    public class OfertaController : Controller
    {
        private readonly IOfertaService _ofertaService;

        public OfertaController(IOfertaService ofertaService)
        {
            _ofertaService = ofertaService;
        }

        /// <summary>
        /// Adicionar uma Oferta
        /// </summary>
        /// <param name="model">Objeto para a criãção de uma Oferta</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Se a Oferta foi Criada </response>
        /// <response code="400">Se a Oferta não foi Criada</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdicionarOferta([FromBody] OfertaModel model)
        {
            var oferta = await _ofertaService.AdicionarOferta(model);

            if(oferta.Notificacao.Any())
            {
                return BadRequest(oferta.Notificacao);
            }

            return Ok(oferta);
        }

        /// <summary>
        /// Rertornar uma Oferta
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <param name="id">Objeto para a encontrar a Oferta</param>
        /// <response code="200">Se a Oferta foi encontrada </response>
        /// <response code="404">Se a Oferta não foi encontrada</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOferta(Guid id)
        {
            var oferta = await _ofertaService.GetOferta(id);
            
            if(oferta == null)
            {
                return NotFound();
            }

            return Ok(oferta);
        }

        /// <summary>
        /// Retorna todas as Ofertas
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Se as Ofertas foram retornadas </response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllOfertas()
        {
            return Ok(await _ofertaService.GetAllOferta());
        }

        /// <summary>
        /// Deletar uma Oferta
        /// </summary>
        /// <param name="id">Objeto para a encontrar a Oferta</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Se a Oferta foi Deletada </response>
        /// <response code="404">Se a Oferta não foi encontrada</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteOferta(Guid id)
        {
            var deletado = await _ofertaService.DeletarOferta(id);
            if (deletado)
                return NoContent();

            return NotFound();
        }

        /// <summary>
        /// Atualiza uma Oferta
        /// </summary>
        /// <param name="model">Objeto para a Atualizacao de uma Oferta</param>
        /// <param name="id">Objeto para a encontrar a Oferta</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Se a Inscrição foi Aualizada </response>
        /// <response code="400">Se a Inscrição não foi Encontrada</response>
        /// <response code="404">Se a Inscrição não foi Atualizada</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutOferta([FromBody] OfertaModel model, Guid id)
        {
            var oferta = await _ofertaService.AtualizarOferta(id, model);

            if(oferta == null)
            {
                return NotFound();
            }
            if(oferta.Notificacao.Any())
            {
                return BadRequest(oferta.Notificacao);
            }

            return NoContent();
        }
    }
}
