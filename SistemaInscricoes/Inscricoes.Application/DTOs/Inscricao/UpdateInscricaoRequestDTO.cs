using Inscricoes.Domain.Enums;
using Inscricoes.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace Inscricoes.Application.DTOs.Inscricao;

public record UpdateInscricaoRequestDTO
{
	[Required(ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_INSCRICAO_STATUS_IS_REQUIRED)]
	public InscricaoStatus Status { get; set; }
}
