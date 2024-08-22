using VestibularApi.API.Requests;
using VestibularApi.API.Responses;

namespace VestibularApi.Application.Services.Interfaces
{
    public interface ICandidatoService
    {
        Task<IEnumerable<CandidatoResponse>> ObterTodosAsync();
        Task<CandidatoResponse> ObterPorIdAsync(Guid id);
        Task<CandidatoResponse> CriarAsync(CandidatoRequest candidatoRequest);
        Task AtualizarAsync(Guid id, CandidatoRequest candidatoRequest);
        Task DeletarAsync(Guid id);
    }
}
