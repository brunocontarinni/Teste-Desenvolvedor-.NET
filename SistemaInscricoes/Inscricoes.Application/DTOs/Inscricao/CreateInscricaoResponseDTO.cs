using Inscricoes.Domain.Enums;

namespace Inscricoes.Application.DTOs.Inscricao;

public record CreateInscricaoResponseDTO
{
	public int InscricaoId { get; set; }
	public string? NumeroInscricao { get; set; }
	public DateTime Data { get; set; }
	public InscricaoStatus Status { get; set; }
	public int LeadId { get; set; }
	public int ProcessoSeletivoId { get; set; }
	public int OfertaId { get; set; }
}
