namespace Inscricoes.Application.DTOs.Inscricao;

public record DeleteInscricaoResponseDTO
{
	public int InscricaoId { get; set; }
	public string? NumeroInscricao { get; set; }
}
