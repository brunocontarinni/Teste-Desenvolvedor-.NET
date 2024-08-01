using SistemaCRM.Models;

namespace SistemaCRM.Repositorio.Interfaces
{
    public interface IInscricaoRepositorio
    {
        Task<List<InscricaoModel>> GetAll();
        Task<List<InscricaoModel>> GetAllAtivos();
        Task<InscricaoModel> GetByID(int id);
        Task<List<InscricaoModel>> GetByCPF(string cpf);
        Task<List<InscricaoModel>> GetByIdCurso(int id);
        Task<InscricaoModel> Insert(InscricaoModel inscricao);
        Task<InscricaoModel> Update(InscricaoModel inscricao);
        Task<bool> Delete(int id);

    }
}
