using Inscricoes.Application.DTOs.Lead;
using Inscricoes.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;

namespace Inscricoes.Api.Controllers;

[Route("api/v1/[Controller]")]
[ApiController]
public class LeadController : ControllerBase
{
	private readonly ILeadService _leadService;

	public LeadController(ILeadService leadService)
	{
		_leadService = leadService;
	}

	[HttpGet]
	[Authorize(Roles = "Coordinator")]
	[SwaggerOperation(Summary = "Listar todos os leads", Description = "Recupera uma lista de todos os leads no sistema.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Lista de leads recuperada com sucesso", typeof(IEnumerable<DetailLeadResponseDTO>))]
	public async Task<IActionResult> ListLeads()
	{
		return Ok(await _leadService.GetAllLeads());
	}

	[HttpGet("{id}")]
	[Authorize(Roles = "Coordinator")]
	[SwaggerOperation(Summary = "Obter lead por ID", Description = "Recupera os detalhes de um lead específico pelo seu ID.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Lead recuperado com sucesso", typeof(DetailLeadResponseDTO))]
	[SwaggerResponse(StatusCodes.Status404NotFound, "Lead não encontrado")]
	public async Task<IActionResult> DetailLead(int id)
	{
		return Ok(await _leadService.GetLeadById(id));
	}

	[HttpPost]
	[Authorize(Roles = "Candidate")]
	[SwaggerOperation(Summary = "Criar um novo lead", Description = "Cria um novo lead no sistema.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Lead criado com sucesso", typeof(CreateLeadResponseDTO))]
	public async Task<IActionResult> CreateLead([FromBody] CreateLeadRequestDTO leadRequestDTO)
	{
		return Ok(await _leadService.CreateLead(leadRequestDTO));
	}

	[HttpPut("{id}")]
	[Authorize(Roles = "Candidate")]
	[SwaggerOperation(Summary = "Atualizar lead", Description = "Atualiza um lead específico pelo seu ID.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Lead atualizado com sucesso", typeof(UpdateLeadResponseDTO))]
	[SwaggerResponse(StatusCodes.Status404NotFound, "Lead não encontrado")]
	public async Task<IActionResult> UpdateLead(int id, [FromBody] UpdateLeadRequestDTO leadRequestDTO)
	{
		return Ok(await _leadService.UpdateLead(id, leadRequestDTO));
	}

	[HttpDelete("{id}")]
	[Authorize(Roles = "Coordinator")]
	[SwaggerOperation(Summary = "Excluir lead", Description = "Exclui um lead específico pelo seu ID.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Lead excluído com sucesso", typeof(DeleteLeadResponseDTO))]
	[SwaggerResponse(StatusCodes.Status404NotFound, "Lead não encontrado")]
	public async Task<IActionResult> DeleteLead(int id)
	{
		return Ok(await _leadService.DeleteLead(id));
	}
}
