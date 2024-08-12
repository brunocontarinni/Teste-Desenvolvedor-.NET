using CrmTest.DTO;
using CrmTest.Models;

namespace CrmTest.Interface{
    public interface ILeadServices{
        Task<IEnumerable<Lead>> GetAllLeads();
        Task<Lead> GetLeadById(int id);
        Task CreateLead(Lead lead);
        Task UpdateLead(int id, LeadDTO lead);
        Task DeleteLead(int id);
    }
}