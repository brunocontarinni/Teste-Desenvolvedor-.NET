using SistemaCRM.Models;

namespace SistemaCRM.Repositorio.Interfaces
{
    public interface ICandidatoRepositorio
    {
        Task<List<CandidatoModel>> GetAll();
        Task<CandidatoModel> GetByID(int id);
        Task<CandidatoModel> GetByCPF(string cpf);
        Task<CandidatoModel> Insert(CandidatoModel candidato);
        Task<CandidatoModel> Update(CandidatoModel candidato);
        Task<bool> Delete(int id);

    }
}
