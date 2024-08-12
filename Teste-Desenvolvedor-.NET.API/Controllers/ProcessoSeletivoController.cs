using Microsoft.AspNetCore.Mvc;
using Teste_Desenvolvedor_.NET.Models.Models;

namespace Teste_Desenvolvedor_.NET.API.Controllers
{
    [ApiController]
    [Route("api/v1/processo-seletivo")]
    public class ProcessoSeletivoController : Controller
    {
        /// <summary>
        /// Adicionar um Processo Seletivo
        /// </summary>
        /// <param name="model">Objeto para a criãção de um Processo Seletivo</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Se o Processo Seletivo foi Criado </response>
        /// <response code="400">Se o Processo Seletivo não foi Criado</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdicionarProcessoSeletivo([FromBody] ProcessoSeletivoModel model)
        {
            return Ok();
        }

        /// <summary>
        /// Retornar um Processo Seletivo
        /// </summary>
        /// <param name="id">Objeto para a encontrar o Processo Seletivo</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Se o Processo Seletivo foi encontrado </response>
        /// <response code="404">Se o Processo Seletivo não foi encontrado</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetProcessoSeletivo(Guid id)
        {
            return Ok();
        }

        /// <summary>
        /// Retorna todos os Processo Seletivos
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Se os Processos Seletivos foram retornados </response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllProcessoSeletivo()
        {
            return Ok();
        }

        /// <summary>
        /// Deleta um Processo Seletivo
        /// </summary>
        /// <param name="id">Objeto para a encontrar o Processo Seletivo</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Se o Processo Seletivo foi Deletado </response>
        /// <response code="404">Se o Processo Seletivo não foi encontrado</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteProcessoSeletivo(Guid id)
        {
            return Ok();
        }

        /// <summary>
        /// Atualiza um Processo Seletivo
        /// </summary>
        /// <param name="model">Objeto para a Atualizacao de um Processo Seletivo</param>
        /// <param name="id">Objeto para a encontrar o Processo Seletivo</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Se o Processo Seletivo foi Aualizado </response>
        /// <response code="404">Se o Processo Seletivo não foi encontrado</response>
        /// <response code="400">Se o Processo Seletivo não foi Atualizado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutProcessoSeletivo([FromBody] ProcessoSeletivoModel model, Guid id)
        {
            return Ok();
        }
    }
}
