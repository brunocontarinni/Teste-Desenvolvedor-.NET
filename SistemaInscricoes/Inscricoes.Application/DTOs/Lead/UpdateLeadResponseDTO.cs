namespace Inscricoes.Application.DTOs.Lead;

public record UpdateLeadResponseDTO
{
	public int LeadId { get; set; }
	public string? Nome { get; set; }
	public string? Email { get; set; }
	public string? Telefone { get; set; }
	public string? CPF { get; set; }
}
