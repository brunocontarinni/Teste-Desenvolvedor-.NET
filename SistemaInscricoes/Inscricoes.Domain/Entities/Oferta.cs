namespace Inscricoes.Domain.Entities;

public class Oferta
{
	public int OfertaId { get; set; }
	public string? Nome { get; set; }
	public string? Descricao { get; set; }
	public int VagasDisponiveis { get; set; }

	public virtual ICollection<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();
}