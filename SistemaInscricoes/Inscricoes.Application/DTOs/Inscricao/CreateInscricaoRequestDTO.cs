using Inscricoes.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace Inscricoes.Application.DTOs.Inscricao;

public record CreateInscricaoRequestDTO
{
	[Required(ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_ID_IS_REQUIRED)]
	public int LeadId { get; set; }

	[Required(ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_ID_IS_REQUIRED)]
	public int ProcessoSeletivoId { get; set; }

	[Required(ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_ID_IS_REQUIRED)]
	public int OfertaId { get; set; }
}