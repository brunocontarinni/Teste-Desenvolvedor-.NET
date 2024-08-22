using VestibularApi.Domain.Entities;

namespace VestibularApi.Domain.Repositories.Interfaces
{
    public interface IInscricaoRepository
    {
        Task<InscricaoEntities> PegarPorIdAsync(Guid id);
        Task<IEnumerable<InscricaoEntities>> PegarTodasAsync();
        Task AdicionarAsync(InscricaoEntities inscricao);
        Task AtualizarAsync(InscricaoEntities inscricao);
        Task DeletarAsync(Guid id);
    }
}
