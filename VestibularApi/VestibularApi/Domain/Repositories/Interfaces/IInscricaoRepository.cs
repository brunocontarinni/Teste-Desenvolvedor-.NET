using VestibularApi.Domain.Entities;

namespace VestibularApi.Domain.Repositories.Interfaces
{
    public interface IInscricaoRepository
    {
        Task<InscricaoEntities> PegarPorIdAsync(Guid id);
        Task AdicionarAsync(InscricaoEntities inscricao);
        Task AtualizarAsync(InscricaoEntities inscricao);
        Task DeletarAsync(Guid id);
        Task<IEnumerable<InscricaoEntities>> PegarTodasAsync();
        Task<IEnumerable<InscricaoEntities>> PegarPorCpfAsync(string cpf);
        Task<IEnumerable<InscricaoEntities>> PegarPorOfertaAsync(Guid ofertaId);
    }
}
