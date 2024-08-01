using SistemaCRM.Models;

namespace SistemaCRM.Repositorio.Interfaces
{
    public interface IProcessoRepositorio
    {

        Task<List<ProcessoModel>> GetAll();
        Task<ProcessoModel> GetByID(int id);
        Task<ProcessoModel> Insert(ProcessoModel processo);
        Task<ProcessoModel> Update(ProcessoModel processo);
        Task<bool> Delete(int id);

    }

}
