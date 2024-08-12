namespace Inscricoes.Application.DTOs.Oferta;

public record DeleteOfertaResponseDTO
{
	public int OfertaId { get; set; }
	public string? Nome { get; set; }
}
