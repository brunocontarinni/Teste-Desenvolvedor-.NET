using Inscricoes.Application.DTOs.Lead;

namespace Inscricoes.Application.Interfaces;

public interface ILeadService
{
	Task<DetailLeadResponseDTO> CreateLead(CreateLeadRequestDTO leadRequestDTO);
	Task<UpdateLeadResponseDTO> UpdateLead(int leadId, UpdateLeadRequestDTO leadRequestDTO);
	Task<DetailLeadResponseDTO> GetLeadById(int leadId);
	Task<IEnumerable<DetailLeadResponseDTO>> GetAllLeads();
	Task<DeleteLeadResponseDTO> DeleteLead(int leadId);
}
