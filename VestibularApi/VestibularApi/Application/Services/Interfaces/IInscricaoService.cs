using VestibularApi.API.Requests;
using VestibularApi.API.Responses;

namespace VestibularApi.Application.Services.Interfaces
{
    public interface IInscricaoService
    {
        Task<IEnumerable<InscricaoResponse>> ObterTodasAsync();
        Task<InscricaoResponse> ObterPorIdAsync(Guid id);
        Task<InscricaoResponse> CriarAsync(InscricaoRequest inscricaoRequest);
        Task<InscricaoResponse> AtualizarAsync(Guid id, InscricaoRequest inscricaoRequest);
        Task DeletarAsync(Guid id);
        Task<IEnumerable<InscricaoResponse>> PegarPorCpfAsync(string cpf);
        Task<IEnumerable<InscricaoResponse>> PegarPorOfertaAsync(Guid ofertaId);
    }
}
