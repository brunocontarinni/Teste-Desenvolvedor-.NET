using Inscricoes.Shared.Constants;
using System.ComponentModel.DataAnnotations;

namespace Inscricoes.Application.DTOs.ProcessoSeletivo;

public record CreateProcessoSeletivoRequestDTO
{
	[Required(ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_PROCESSO_SELETIVO_NAME_IS_REQUIRED)]
	[StringLength(100, ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_FIELD_STRING_LENGTH)]
	public string? Nome { get; set; }

	[Required(ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_PROCESSO_SELETIVO_DATE_START_IS_REQUIRED)]
	public DateTime DataInicio { get; set; }

	[Required(ErrorMessage = MessageKeyConstants.MESSAGE_ERROR_PROCESSO_SELETIVO_DATE_END_IS_REQUIRED)]
	public DateTime DataTermino { get; set; }
}
