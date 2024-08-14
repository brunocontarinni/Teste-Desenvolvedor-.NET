using Teste_Desenvolvedor_.NET.Domain.Entities;

namespace Teste_Desenvolvedor_.NET.Services.Interfaces
{
    public interface IUtilsService
    {
        Task<IEnumerable<Inscricao>> GetAllDeletedInscricoes();
        Task<IEnumerable<Lead>> GetAllDeletedLeads();
        Task<IEnumerable<Oferta>> GetAllDeletedOferta();
        Task<IEnumerable<ProcessoSeletivo>> GetAllDeletedProcessoSeletivo();

        Task<bool> Deletar(Guid id);
    }
}
