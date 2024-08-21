using VestibularApi.Domain.Entities;

namespace VestibularApi.Domain.Repositories
{
    public interface ICandidatoRepository
    {
        Task<Candidato> PegarPorIdAsync(Guid id);
        Task<IEnumerable<Candidato>> PegarTodosAsync();
        Task AdicionarAsync(Candidato candidato);
        Task AtualizarAsync(Candidato candidato);
        Task DeletarAsync(Guid id);
    }
}
