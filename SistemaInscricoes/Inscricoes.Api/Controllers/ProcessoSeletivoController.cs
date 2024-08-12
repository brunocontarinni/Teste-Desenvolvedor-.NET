using Inscricoes.Application.DTOs.ProcessoSeletivo;
using Inscricoes.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Inscricoes.Api.Controllers;

[Route("api/v1/[Controller]")]
[ApiController]
public class ProcessoSeletivoController : ControllerBase
{
	private readonly IProcessoSeletivoService _processoSeletivoService;

	public ProcessoSeletivoController(IProcessoSeletivoService processoSeletivoService)
	{
		_processoSeletivoService = processoSeletivoService;
	}

	[HttpGet]
	[Authorize]
	[SwaggerOperation(Summary = "Listar todos os processos seletivos", Description = "Recupera uma lista de todos os processos seletivos no sistema.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Lista de processos seletivos recuperada com sucesso", typeof(IEnumerable<DetailProcessoSeletivoResponseDTO>))]
	public async Task<IActionResult> ListProcessosSeletivos()
	{
		return Ok(await _processoSeletivoService.GetAllProcessosSeletivos());
	}

	[HttpGet("{id}")]
	[Authorize]
	[SwaggerOperation(Summary = "Obter processo seletivo por ID", Description = "Recupera os detalhes de um processo seletivo específico pelo seu ID.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Processo seletivo recuperado com sucesso", typeof(DetailProcessoSeletivoResponseDTO))]
	[SwaggerResponse(StatusCodes.Status404NotFound, "Processo seletivo não encontrado")]
	public async Task<IActionResult> DetailProcessoSeletivo(int id)
	{
		return Ok(await _processoSeletivoService.GetProcessoSeletivoById(id));
	}

	[HttpPost]
	[Authorize(Roles = "Coordinator")]
	[SwaggerOperation(Summary = "Criar um novo processo seletivo", Description = "Cria um novo processo seletivo no sistema.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Processo seletivo criado com sucesso", typeof(CreateProcessoSeletivoResponseDTO))]
	public async Task<IActionResult> CreateProcessoSeletivo([FromBody] CreateProcessoSeletivoRequestDTO processoSeletivoRequestDTO)
	{
		return Ok(await _processoSeletivoService.CreateProcessoSeletivo(processoSeletivoRequestDTO));
	}

	[HttpPut("{id}")]
	[Authorize(Roles = "Coordinator")]
	[SwaggerOperation(Summary = "Atualizar processo seletivo", Description = "Atualiza um processo seletivo específico pelo seu ID.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Processo seletivo atualizado com sucesso", typeof(UpdateProcessoSeletivoResponseDTO))]
	[SwaggerResponse(StatusCodes.Status404NotFound, "Processo seletivo não encontrado")]
	public async Task<IActionResult> UpdateProcessoSeletivo(int id, [FromBody] UpdateProcessoSeletivoRequestDTO processoSeletivoRequestDTO)
	{
		return Ok(await _processoSeletivoService.UpdateProcessoSeletivo(id, processoSeletivoRequestDTO));
	}

	[HttpDelete("{id}")]
	[Authorize(Roles = "Coordinator")]
	[SwaggerOperation(Summary = "Excluir processo seletivo", Description = "Exclui um processo seletivo específico pelo seu ID.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Processo seletivo excluído com sucesso", typeof(DeleteProcessoSeletivoResponseDTO))]
	[SwaggerResponse(StatusCodes.Status404NotFound, "Processo seletivo não encontrado")]
	public async Task<IActionResult> DeleteProcessoSeletivo(int id)
	{
		return Ok(await _processoSeletivoService.DeleteProcessoSeletivo(id));
	}
}
