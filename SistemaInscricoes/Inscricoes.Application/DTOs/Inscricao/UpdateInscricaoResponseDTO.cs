using Inscricoes.Domain.Enums;

namespace Inscricoes.Application.DTOs.Inscricao;

public record UpdateInscricaoResponseDTO
{
	public int InscricaoId { get; set; }
	public InscricaoStatus Status { get; set; }
}
