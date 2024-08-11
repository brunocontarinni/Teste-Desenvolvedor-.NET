using Inscricoes.Application.DTOs.Oferta;
using Inscricoes.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Inscricoes.Api.Controllers;

[Route("api/v1/[Controller]")]
[ApiController]
public class OfertaController : ControllerBase
{
	private readonly IOfertaService _ofertaService;

	public OfertaController(IOfertaService ofertaService)
	{
		_ofertaService = ofertaService;
	}

	[HttpGet]
	[Authorize]
	[SwaggerOperation(Summary = "Listar todas as ofertas", Description = "Recupera uma lista de todas as ofertas no sistema.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Lista de ofertas recuperada com sucesso", typeof(IEnumerable<DetailOfertaResponseDTO>))]
	public async Task<IActionResult> ListOfertas()
	{
		return Ok(await _ofertaService.GetAllOfertas());
	}

	[HttpGet("{id}")]
	[Authorize]
	[SwaggerOperation(Summary = "Obter oferta por ID", Description = "Recupera os detalhes de uma oferta específica pelo seu ID.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Oferta recuperada com sucesso", typeof(DetailOfertaResponseDTO))]
	[SwaggerResponse(StatusCodes.Status404NotFound, "Oferta não encontrada")]
	public async Task<IActionResult> DetailOferta(int id)
	{
		return Ok(await _ofertaService.GetOfertaById(id));
	}

	[HttpPost]
	[Authorize(Roles = "Coordinator")]
	[SwaggerOperation(Summary = "Criar uma nova oferta", Description = "Cria uma nova oferta no sistema.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Oferta criada com sucesso", typeof(CreateOfertaResponseDTO))]
	public async Task<IActionResult> CreateOferta([FromBody] CreateOfertaRequestDTO ofertaRequestDTO)
	{
		return Ok(await _ofertaService.CreateOferta(ofertaRequestDTO));
	}

	[HttpPut("{id}")]
	[Authorize(Roles = "Coordinator")]
	[SwaggerOperation(Summary = "Atualizar oferta", Description = "Atualiza uma oferta específica pelo seu ID.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Oferta atualizada com sucesso", typeof(UpdateOfertaResponseDTO))]
	[SwaggerResponse(StatusCodes.Status404NotFound, "Oferta não encontrada")]
	public async Task<IActionResult> UpdateOferta(int id, [FromBody] UpdateOfertaRequestDTO ofertaRequestDTO)
	{
		return Ok(await _ofertaService.UpdateOferta(id, ofertaRequestDTO));
	}

	[HttpDelete("{id}")]
	[Authorize(Roles = "Coordinator")]
	[SwaggerOperation(Summary = "Excluir oferta", Description = "Exclui uma oferta específica pelo seu ID.")]
	[SwaggerResponse(StatusCodes.Status200OK, "Oferta excluída com sucesso", typeof(DeleteOfertaResponseDTO))]
	[SwaggerResponse(StatusCodes.Status404NotFound, "Oferta não encontrada")]
	public async Task<IActionResult> DeleteOferta(int id)
	{
		return Ok(await _ofertaService.DeleteOferta(id));
	}
}
