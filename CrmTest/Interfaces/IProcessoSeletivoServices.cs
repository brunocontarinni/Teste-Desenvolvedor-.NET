using CrmTest.DTO;
using CrmTest.Models;

namespace CrmTest.Interface{
    public interface IProcessoSeletivoServices{
        Task<IEnumerable<ProcessoSeletivo>> GetAllProcessoSeletivos();
        Task<ProcessoSeletivo> GetProcessoSeletivoById(int id);
        Task CreateProcessoSeletivo(ProcessoSeletivo ProcessoSeletivo);
        Task UpdateProcessoSeletivo(int id, ProcessoSeletivoDTO ProcessoSeletivo);
        Task DeleteProcessoSeletivo(int id);
    }
}