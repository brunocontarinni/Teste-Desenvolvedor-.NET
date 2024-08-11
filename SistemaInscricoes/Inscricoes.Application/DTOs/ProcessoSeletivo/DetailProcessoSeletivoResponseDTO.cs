namespace Inscricoes.Application.DTOs.ProcessoSeletivo;

public record DetailProcessoSeletivoResponseDTO
{
	public int ProcessoSeletivoId { get; set; }
	public string? Nome { get; set; }
	public DateTime DataInicio { get; set; }
	public DateTime DataTermino { get; set; }
}
