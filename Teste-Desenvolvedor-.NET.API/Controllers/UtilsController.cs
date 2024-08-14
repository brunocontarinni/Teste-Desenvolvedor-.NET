using Microsoft.AspNetCore.Mvc;
using Teste_Desenvolvedor_.NET.Services.Interfaces;

namespace Teste_Desenvolvedor_.NET.API.Controllers
{
    [ApiController]
    [Route("api/v1/utils")]
    public class UtilsController : Controller
    {

        private readonly IUtilsService _utilsService;

        public UtilsController(IUtilsService utilsService)
        {
            _utilsService = utilsService;
        }

        /// <summary>
        /// Retornar Todas as Inscrições Deletadas
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Se as Inscrições foram retornadas </response>
        [HttpGet("inscricao")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDeletedInscicao()
        {
            return Ok(await _utilsService.GetAllDeletedInscricoes());
        }

        /// <summary>
        /// Retornar Todos os Lead Deletados
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Se os leads foram retornadas </response>
        [HttpGet("lead")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDeletedLead()
        {
            return Ok(await _utilsService.GetAllDeletedLeads());
        }

        /// <summary>
        /// Retornar Todas as Ofertas Deletadas
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Se as Ofertas foram retornadas </response>
        [HttpGet("oferta")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDeletedOferta()
        {
            return Ok(await _utilsService.GetAllDeletedOferta());
        }

        /// <summary>
        /// Retornar Todos os Processos Seletivos Deletados
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Se os Processos Seletivos foram retornadas </response>
        [HttpGet("processo-seletivo")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllDeletedProcesso()
        {
            return Ok(await _utilsService.GetAllDeletedProcessoSeletivo());
        }

        /// <summary>
        /// Deleta uma entidade definitivamente
        /// </summary>
        /// <param name="id">Objeto para a encontrar a entidade</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Se a entidade foi Deletada </response>
        /// <response code="404">Se a entidade Seletivo não foi encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProcessoSeletivo(Guid id)
        {
            var deletado = await _utilsService.Deletar(id);
            if (deletado)
                return NoContent();
            return NotFound();
        }



    }
}
