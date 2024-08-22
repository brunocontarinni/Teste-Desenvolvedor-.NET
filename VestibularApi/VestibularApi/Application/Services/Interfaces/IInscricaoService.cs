using VestibularApi.API.Requests;
using VestibularApi.API.Responses;
using VestibularApi.Domain.Entities;

namespace VestibularApi.Application.Services.Inscricao
{
    public interface IInscricaoService
    {
        Task<IEnumerable<InscricaoResponse>> ObterTodasAsync();
        Task<InscricaoResponse> ObterPorIdAsync(Guid id);
        Task<InscricaoResponse> CriarAsync(InscricaoRequest inscricaoRequest);
        Task<InscricaoResponse> AtualizarAsync(Guid id, InscricaoRequest inscricaoRequest);
        Task DeletarAsync(Guid id);
    }
}
