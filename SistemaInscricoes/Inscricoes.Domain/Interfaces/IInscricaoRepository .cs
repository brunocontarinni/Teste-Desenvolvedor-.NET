using Inscricoes.Domain.Entities;

namespace Inscricoes.Domain.Interfaces;

public interface IInscricaoRepository : IBaseRepository<Inscricao>
{
	Task<IEnumerable<Inscricao>> GetByCpfAsync(string cpf);
	Task<IEnumerable<Inscricao>> GetByOfertaIdAsync(int ofertaId);
}
