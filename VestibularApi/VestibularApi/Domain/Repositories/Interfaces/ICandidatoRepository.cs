using VestibularApi.Domain.Entities;

namespace VestibularApi.Domain.Repositories.Interfaces
{
    public interface ICandidatoRepository
    {
        Task<CandidatoEntities> PegarPorIdAsync(Guid id);
        Task<IEnumerable<CandidatoEntities>> PegarTodosAsync();
        Task AdicionarAsync(CandidatoEntities candidato);
        Task AtualizarAsync(CandidatoEntities candidato);
        Task DeletarAsync(Guid id);
    }
}
