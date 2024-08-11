using Inscricoes.Domain.Entities;

namespace Inscricoes.Domain.Interfaces;

public interface IOfertaRepository : IBaseRepository<Oferta>
{
	Task<Oferta?> GetByIdWithInscricoes(int ofertaId);
}
