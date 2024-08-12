using Inscricoes.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace Inscricoes.Application.DTOs.Lead;

public record UpdateLeadRequestDTO
{
	[Required(ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_NAME_IS_REQUIRED)]
	[StringLength(100, ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_FIELD_STRING_LENGTH)]
	public string? Nome { get; set; }

	[Required(ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_EMAIL_IS_REQUIRED)]
	[EmailAddress(ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_EMAIL_INVALID)]
	[StringLength(100, ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_FIELD_STRING_LENGTH)]
	public string? Email { get; set; }

	[StringLength(15, ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_FIELD_STRING_LENGTH)]
	public string? Telefone { get; set; }
}
