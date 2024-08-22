using VestibularApi.API.Requests;
using VestibularApi.API.Responses;

namespace VestibularApi.Application.Services.Interfaces
{
    public interface IProcessoSeletivoService
    {
        Task<IEnumerable<ProcessoSeletivoResponse>> ObterTodosAsync();
        Task<ProcessoSeletivoResponse> ObterPorIdAsync(Guid id);
        Task<ProcessoSeletivoResponse> CriarAsync(ProcessoSeletivoRequest processoSeletivoRequest);
        Task AtualizarAsync(Guid id, ProcessoSeletivoRequest processoSeletivoRequest);
        Task DeletarAsync(Guid id);
    }
}
