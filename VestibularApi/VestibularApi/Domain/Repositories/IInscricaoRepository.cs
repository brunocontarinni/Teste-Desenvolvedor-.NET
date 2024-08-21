using VestibularApi.Domain.Entities;

namespace VestibularApi.Domain.Repositories
{
    public interface IInscricaoRepository
    {
        Task<Inscricao> PegarPorIdAsync(Guid id);
        Task<IEnumerable<Inscricao>> PegarTodasAsync();
        Task AdicionarAsync(Inscricao inscricao);
        Task AtualizarAsync(Inscricao inscricao);
        Task DeletarAsync(Guid id);
    }
}
