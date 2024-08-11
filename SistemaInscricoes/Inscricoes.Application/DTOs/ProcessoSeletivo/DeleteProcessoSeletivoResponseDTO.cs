namespace Inscricoes.Application.DTOs.ProcessoSeletivo;

public record DeleteProcessoSeletivoResponseDTO
{
	public int ProcessoSeletivoId { get; set; }
	public string? Nome { get; set; }
}
