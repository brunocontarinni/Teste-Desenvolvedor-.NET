using Microsoft.AspNetCore.Http.HttpResults;
using VestibularApi.API.Requests;
using VestibularApi.API.Responses;

namespace VestibularApi.Application.Services.Interfaces
{
    public interface ILeadService
    {
        Task<IEnumerable<LeadResponse>> ObterTodosAsync();
        Task<LeadResponse> ObterPorIdAsync(Guid id);
        Task<LeadResponse> CriarAsync(LeadRequest leadRequest);
        Task AtualizarAsync(Guid id, LeadRequest leadRequest);
        Task DeletarAsync(Guid id);
    }
}
