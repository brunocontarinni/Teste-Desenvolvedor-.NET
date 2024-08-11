namespace Inscricoes.Domain.Entities;

public class ProcessoSeletivo
{
	public int ProcessoSeletivoId { get; set; }
	public string? Nome { get; set; }
	public DateTime DataInicio { get; set; }
	public DateTime DataTermino { get; set; }

	public virtual ICollection<Inscricao>? Inscricoes { get; set; } = new List<Inscricao>();
}