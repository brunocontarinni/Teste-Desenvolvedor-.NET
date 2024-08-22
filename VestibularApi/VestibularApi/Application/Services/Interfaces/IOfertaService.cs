using VestibularApi.API.Requests;
using VestibularApi.API.Responses;

namespace VestibularApi.Application.Services.Interfaces
{
    public interface IOfertaService
    {
        Task<IEnumerable<OfertaResponse>> ObterTodasAsync();
        Task<OfertaResponse> ObterPorIdAsync(Guid id);
        Task<OfertaResponse> CriarAsync(OfertaRequest ofertaRequest);
        Task AtualizarAsync(Guid id, OfertaRequest ofertaRequest);
        Task DeletarAsync(Guid id);
    }
}
