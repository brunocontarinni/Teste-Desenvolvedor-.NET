using SistemaCRM.Models;

namespace SistemaCRM.Repositorio.Interfaces
{
    public interface ICursoRepositorio
    {
        Task<List<CursoModel>> GetAll();
        Task<CursoModel> GetByID(int id);
        Task<CursoModel> Insert(CursoModel oferta);
        Task<CursoModel> Update(CursoModel oferta);
        Task<bool> Delete(int id);
    }
}
