namespace Inscricoes.Domain.Entities;

public class Lead
{
	public int LeadId { get; set; }
	public string? Nome { get; set; }
	public string? Email { get; set; }
	public string? Telefone { get; set; }
	public string? CPF { get; set; }

	public virtual ICollection<Inscricao>? Inscricoes { get; set; }
}
