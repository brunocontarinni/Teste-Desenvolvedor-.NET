using Inscricoes.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace Inscricoes.Application.DTOs.ProcessoSeletivo;

public record UpdateProcessoSeletivoRequestDTO
{
	[Required(ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_PROCESSO_SELETIVO_NAME_IS_REQUIRED)]
	[StringLength(100, ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_FIELD_STRING_LENGTH)]
	public string? Nome { get; set; }
}
