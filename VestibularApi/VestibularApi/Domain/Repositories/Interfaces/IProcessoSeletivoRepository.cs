using VestibularApi.Domain.Entities;

namespace VestibularApi.Domain.Repositories
{
    public interface IProcessoSeletivoRepository
    {
        Task<ProcessoSeletivoEntities> PegarPorIdAsync(Guid id);
        Task<IEnumerable<ProcessoSeletivoEntities>> PegarTodosAsync();
        Task AdicionarAsync(ProcessoSeletivoEntities processoSeletivo);
        Task AtualizarAsync(ProcessoSeletivoEntities processoSeletivo);
        Task DeletarAsync(Guid id);
    }
}
