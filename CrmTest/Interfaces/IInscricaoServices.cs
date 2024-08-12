using CrmTest.Models;
using CrmTest.DTO;

namespace CrmTest.AppDataContext
{
    public interface IInscricaoServices
    {
        Task<IEnumerable<Inscricao>> GetAllInscricoes();
        Task<Inscricao> GetInscricaoById(int id);
        Task CreateInscricao(Inscricao Inscricao);
        Task UpdateInscricao(int id, InscricaoDTO Inscricao);
        Task DeleteInscricao(int id);
    }
}

