namespace Inscricoes.Application.DTOs.Oferta;

public record UpdateOfertaResponseDTO
{
	public int OfertaId { get; set; }
	public string? Nome { get; set; }
	public string? Descricao { get; set; }
	public int VagasDisponiveis { get; set; }
}
