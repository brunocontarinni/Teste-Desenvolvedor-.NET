using Inscricoes.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace Inscricoes.Application.DTOs.Oferta;

public record UpdateOfertaRequestDTO
{
	[Required(ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_OFERTA_NAME_IS_REQUIRED)]
	[StringLength(100, ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_FIELD_STRING_LENGTH)]
	public string? Nome { get; set; }

	[StringLength(500, ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_FIELD_STRING_LENGTH)]
	public string? Descricao { get; set; }

	[Required(ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_OFERTA_VAGAS_DISPONIVEIS_IS_REQUIRED)]
	[Range(1, int.MaxValue, ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_OFERTA_VAGAS_DISPONIVEIS_INVALID)]
	public int VagasDisponiveis { get; set; }
}
