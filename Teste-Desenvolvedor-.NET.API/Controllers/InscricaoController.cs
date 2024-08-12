using Microsoft.AspNetCore.Mvc;
using Teste_Desenvolvedor_.NET.Models.Models;

namespace Teste_Desenvolvedor_.NET.API.Controllers
{
    [ApiController]
    [Route("api/v1/inscicao")]
    public class InscricaoController : Controller
    {
        /// <summary>
        /// Adicionar uma Inscrição
        /// </summary>
        /// <param name="model">Objeto para a criãção de uma Inscrição</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Se a Inscrição foi Criada </response>
        /// <response code="400">Se a Inscrição não foi Criada</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AdicionarInscricao([FromBody] InscricaoModel model)
        {
            return Ok();
        }

        /// <summary>
        /// Retornar Uma Inscrição
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Se a Inscrição foi encontrada </response>
        /// <response code="400">Se a Inscrição não foi encontrada</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetInscicao(Guid id)
        {
            return Ok();
        }

        /// <summary>
        /// Retornar Todas as Inscrições
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Se as Inscrições foram retornadas </response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllInscicao()
        {
            return Ok();
        }

        /// <summary>
        /// Deletar uma Inscrição
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="204">Se a Inscrição foi Deletada </response>
        /// <response code="400">Se a Inscrição não foi encontrada</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteInscicao(Guid id)
        {
            return Ok();
        }

        /// <summary>
        /// Atualizar uma Inscrição
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="204">Se a Inscrição foi Aualizada </response>
        /// <response code="400">Se a Inscrição não foi encontrada</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutInscicao([FromBody]InscricaoModel model, Guid id)
        {
            return Ok();
        }



    }
}
