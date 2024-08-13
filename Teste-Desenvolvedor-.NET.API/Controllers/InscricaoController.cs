using Microsoft.AspNetCore.Mvc;
using Teste_Desenvolvedor_.NET.Models.Models;
using Teste_Desenvolvedor_.NET.Services.Interfaces;

namespace Teste_Desenvolvedor_.NET.API.Controllers
{
    [ApiController]
    [Route("api/v1/inscricao")]
    public class InscricaoController : Controller
    {

        private readonly IInscricaoService _inscricaoService;

        public InscricaoController(IInscricaoService inscricaoService)
        {
            _inscricaoService = inscricaoService;
        }

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
            var inscricao = await _inscricaoService.AdicionarInscricao(model);

            if(inscricao.Notificacao.Any())
            {
                return BadRequest(inscricao.Notificacao);
            }

            return Ok(inscricao);
        }

        /// <summary>
        /// Retornar Uma Inscrição
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="200">Se a Inscrição foi encontrada </response>
        /// <response code="404">Se a Inscrição não foi encontrada</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInscicao(Guid id)
        {
            var inscricao = await _inscricaoService.GetInscricao(id);
            if(inscricao == null)
            {
                return NotFound();
            }

            return Ok(inscricao);
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
            return Ok(await _inscricaoService.GetAllInscricao());
        }

        /// <summary>
        /// Deletar uma Inscrição
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <response code="204">Se a Inscrição foi Deletada </response>
        /// <response code="404">Se a Inscrição não foi encontrada</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteInscicao(Guid id)
        {
            var deletado = await _inscricaoService.DeletarInscricao(id);
            
            if (deletado)
                return NoContent();

            return NotFound();
        }

        /// <summary>
        /// Atualizar uma Inscrição
        /// </summary>
        /// <param name="model">Objeto para a Atualizacao de uma Inscrição</param>
        /// <param name="id">Objeto para a encontrar a Inscição</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Se a Inscrição foi Aualizada </response>
        /// <response code="400">Se a Inscrição não foi encontrada</response>
        /// <response code="404">Se o Lead não foi encontrado</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutInscicao([FromBody]InscricaoModel model, Guid id)
        {
            var inscricao = await _inscricaoService.AtualizarInscricao(id, model);
            if(inscricao == null)
            {
                return NotFound();
            }
            if(inscricao.Notificacao.Any())
            {
                return BadRequest(inscricao.Notificacao);
            }

            return NoContent();

        }


        /// <summary>
        /// Retornar uma lista de Inscrições por CPF
        /// </summary>
        /// <returns>IActionResult</returns>
        /// <param name="cpf">Objeto para a encontrar o Lead</param>
        /// <response code="200">Se a Inscrição foi encontrada </response>
        /// <response code="404">Se o CPF não foi encontrado</response>
        [HttpGet("/cpf/{cpf}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInscicoesCpf(string cpf)
        {
            var inscricoes = await _inscricaoService.GetInscicoesCPF(cpf);

            if(inscricoes == null)
            {
                return NotFound();
            }
            return Ok(inscricoes);
        }

        /// <summary>
        /// Retornar uma lista de Inscrições por Oferta
        /// </summary>
        /// <param name="id">Objeto para a encontrar a Oferta</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Se a Inscrição foi encontrada </response>
        /// <response code="404">Se a Oferta não foi encontrado</response>
        [HttpGet("/oferta/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetInscicoesOferta(Guid id)
        {
            var inscricoes = await _inscricaoService.GetInscicoesOferta(id);
            if (inscricoes == null)
            {
                return NotFound();
            }
            return Ok(inscricoes);
        }


    }
}
