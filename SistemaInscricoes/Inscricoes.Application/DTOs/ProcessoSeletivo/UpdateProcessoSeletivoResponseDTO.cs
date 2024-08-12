namespace Inscricoes.Application.DTOs.ProcessoSeletivo;

public record UpdateProcessoSeletivoResponseDTO
{
	public int ProcessoSeletivoId { get; set; }
	public string? Nome { get; set; }
}
