using VestibularApi.Domain.Entities;

namespace VestibularApi.Domain.Repositories
{
    public interface IOfertaRepository
    {
        Task<Oferta> PegarPorIdAsync(Guid id);
        Task<IEnumerable<Oferta>> PegarTodasAsync();
        Task AdicionarAsync(Oferta oferta);
        Task AtualizarAsync(Oferta oferta);
        Task DeletarAsync(Guid id);
    }
}
