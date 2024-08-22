using VestibularApi.Domain.Entities;

namespace VestibularApi.Domain.Repositories
{
    public interface ILeadRepository
    {
        Task<LeadEntities> PegarPorIdAsync(Guid id);
        Task<IEnumerable<LeadEntities>> PegarTodosAsync();
        Task AdicionarAsync(LeadEntities lead);
        Task AtualizarAsync(LeadEntities lead);
        Task DeletarAsync(Guid id);
    }
}
