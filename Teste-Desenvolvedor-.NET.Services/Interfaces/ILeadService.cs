

using Teste_Desenvolvedor_.NET.Domain.Entities;
using Teste_Desenvolvedor_.NET.Models.Models;

namespace Teste_Desenvolvedor_.NET.Services.Interfaces
{
    public interface ILeadService
    {
        Task<Lead> AdicionarLead(LeadModel model);
        Task<Lead> GetLead(Guid id);
        Task<IEnumerable<Lead>> GetAllLead();
        Task<bool> DeletarLead(Guid id);
        Task<Lead> AtualizarLead(Guid id, LeadModel model);


    }
}
