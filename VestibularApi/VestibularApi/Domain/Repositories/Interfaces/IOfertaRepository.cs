using VestibularApi.Domain.Entities;

namespace VestibularApi.Domain.Repositories.Interfaces
{
    public interface IOfertaRepository
    {
        Task<OfertaEntities> PegarPorIdAsync(Guid id);
        Task<IEnumerable<OfertaEntities>> PegarTodasAsync();
        Task AdicionarAsync(OfertaEntities oferta);
        Task AtualizarAsync(OfertaEntities oferta);
        Task DeletarAsync(Guid id);
    }
}
