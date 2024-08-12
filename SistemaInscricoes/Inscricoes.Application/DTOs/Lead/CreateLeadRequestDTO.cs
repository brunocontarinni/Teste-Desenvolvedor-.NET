using Inscricoes.Application.Validations;
using Inscricoes.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace Inscricoes.Application.DTOs.Lead;

public record CreateLeadRequestDTO
{
	[Required(ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_NAME_IS_REQUIRED)]
	[StringLength(100, MinimumLength = 3, ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_FIELD_STRING_LENGTH)]
	public string? Nome { get; set; }

	[Required(ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_EMAIL_IS_REQUIRED)]
	[EmailAddress(ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_EMAIL_INVALID)]
	[StringLength(100, ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_FIELD_STRING_LENGTH)]
	public string? Email { get; set; }

	[StringLength(15, ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_FIELD_STRING_LENGTH)]
	public string? Telefone { get; set; }

	[Required(ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_CPF_IS_REQUIRED)]
	[StringLength(11, ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_FIELD_STRING_LENGTH)]
	[CpfValidation]
	public string? CPF { get; set; }
}