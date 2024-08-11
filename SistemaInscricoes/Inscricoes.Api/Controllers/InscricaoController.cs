using Inscricoes.Application.DTOs.Inscricao;
using Inscricoes.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Inscricoes.Api.Controllers;

[Route("api/v1/[Controller]")]
[ApiController]
public class InscricaoController : ControllerBase
{
	private readonly IInscricaoService _inscricaoService;

	public InscricaoController(IInscricaoService inscricaoService)
	{
		_inscricaoService = inscricaoService;
	}

	[HttpGet]
	[Authorize(Roles = "Coordinator")]
	[SwaggerOperation(Summary = "Listar todas as inscrições", Description = "Recupera uma lista de todas as inscrições no sistema.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Lista de inscrições recuperada com sucesso", typeof(IEnumerable<DetailInscricaoResponseDTO>))]
	public async Task<IActionResult> ListInscricoes()
	{
		return Ok(await _inscricaoService.GetAllInscricoes());
	}

	[HttpGet("{id}")]
	[Authorize(Roles = "Coordinator")]
	[SwaggerOperation(Summary = "Obter inscrição por ID", Description = "Recupera os detalhes de uma inscrição específica pelo seu ID.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Inscrição recuperada com sucesso", typeof(DetailInscricaoResponseDTO))]
	[SwaggerResponse(StatusCodes.Status404NotFound, "Inscrição não encontrada")]
	public async Task<IActionResult> DetailInscricao(int id)
	{
		return Ok(await _inscricaoService.GetInscricaoById(id));
	}

	[HttpGet("cpf/{cpf}")]
	[Authorize(Roles = "Coordinator")]
	[SwaggerOperation(Summary = "Listar inscrições por CPF", Description = "Recupera uma lista de inscrições associadas a um CPF específico.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Lista de inscrições por CPF recuperada com sucesso", typeof(IEnumerable<DetailInscricaoResponseDTO>))]
	public async Task<IActionResult> ListInscricoesByCpf(string cpf)
	{
		return Ok(await _inscricaoService.GetInscricoesByCpf(cpf));
	}

	[HttpGet("oferta/{ofertaId}")]
	[Authorize(Roles = "Coordinator")]
	[SwaggerOperation(Summary = "Listar inscrições por ID da Oferta", Description = "Recupera uma lista de inscrições associadas a um ID de Oferta específico.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Lista de inscrições por Oferta recuperada com sucesso", typeof(IEnumerable<DetailInscricaoResponseDTO>))]
	public async Task<IActionResult> ListInscricoesByOfertaId(int ofertaId)
	{
		return Ok(await _inscricaoService.GetInscricoesByOfertaId(ofertaId));
	}

	[HttpPost]
	[Authorize(Roles = "Candidate")]
	[SwaggerOperation(Summary = "Criar uma nova inscrição", Description = "Cria uma nova inscrição no sistema.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Inscrição criada com sucesso", typeof(CreateInscricaoResponseDTO))]
	public async Task<IActionResult> CreateInscricao([FromBody] CreateInscricaoRequestDTO inscricaoRequestDTO)
	{
		return Ok(await _inscricaoService.CreateInscricao(inscricaoRequestDTO));
	}

	[HttpPut("{id}")]
	[Authorize(Roles = "Coordinator")]
	[SwaggerOperation(Summary = "Atualizar inscrição", Description = "Atualiza o status de uma inscrição específica pelo seu ID.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Inscrição atualizada com sucesso", typeof(UpdateInscricaoResponseDTO))]
	[SwaggerResponse(StatusCodes.Status404NotFound, "Inscrição não encontrada")]
	public async Task<IActionResult> UpdateInscricao(int id, [FromBody] UpdateInscricaoRequestDTO inscricaoRequestDTO)
	{
		return Ok(await _inscricaoService.UpdateInscricao(id, inscricaoRequestDTO));
	}

	[HttpDelete("{id}")]
	[Authorize]
	[SwaggerOperation(Summary = "Excluir inscrição", Description = "Exclui uma inscrição específica pelo seu ID.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Inscrição excluída com sucesso", typeof(DeleteInscricaoResponseDTO))]
	[SwaggerResponse(StatusCodes.Status404NotFound, "Inscrição não encontrada")]
	public async Task<IActionResult> DeleteInscricao(int id)
	{
		return Ok(await _inscricaoService.DeleteInscricao(id));
	}
}
