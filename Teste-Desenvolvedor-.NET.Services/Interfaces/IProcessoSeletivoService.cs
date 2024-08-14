using Teste_Desenvolvedor_.NET.Domain.Entities;
using Teste_Desenvolvedor_.NET.Models.Models;

namespace Teste_Desenvolvedor_.NET.Services.Interfaces
{
    public interface IProcessoSeletivoService
    {
        Task<ProcessoSeletivo> AdicionarProcessoSeletivo(ProcessoSeletivoModel model);
        Task<ProcessoSeletivo> GetProcessoSeletivo(Guid id);
        Task<IEnumerable<ProcessoSeletivo>> GetAllProcessoSeletivo();
        Task<bool> DeletarProcessoSeletivo(Guid id);
        Task<ProcessoSeletivo> AtualizarProcessoSeletivo(Guid id, ProcessoSeletivoModel model);
    }
}
