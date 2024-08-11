using Inscricoes.Domain.Enums;

namespace Inscricoes.Domain.Entities;

public class Inscricao
{
	public int InscricaoId { get; set; }
	public string NumeroInscricao { get; set; } = string.Empty;
	public DateTime Data { get; set; } = DateTime.UtcNow;
	public InscricaoStatus Status { get; set; } = InscricaoStatus.Pendente;
	public int LeadId { get; set; }
	public int ProcessoSeletivoId { get; set; }
	public int OfertaId { get; set; }

	public virtual Lead Lead { get; set; }
	public virtual ProcessoSeletivo ProcessoSeletivo { get; set; }
	public virtual Oferta Oferta { get; set; }

	public void GerarNumeroInscricao()
	{
		NumeroInscricao = $"{DateTime.UtcNow.Year}{InscricaoId}";
	}
}
