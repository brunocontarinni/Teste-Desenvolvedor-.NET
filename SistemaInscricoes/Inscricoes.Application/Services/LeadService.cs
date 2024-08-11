using Inscricoes.Application.DTOs.Lead;
using Inscricoes.Application.Interfaces;
using Inscricoes.Domain.Entities;
using Inscricoes.Domain.Interfaces;
using Inscricoes.Shared.Exceptions;
using Inscricoes.Shared.Constants;

namespace Inscricoes.Application.Services;

public class LeadService : ILeadService
{
	private readonly ILeadRepository _leadRepository;
	private readonly IMapperService _mapperService;

	public LeadService(ILeadRepository leadRepository, IMapperService mapperService)
	{
		_leadRepository = leadRepository;
		_mapperService = mapperService;
	}

	public async Task<DetailLeadResponseDTO> CreateLead(CreateLeadRequestDTO leadRequestDTO)
	{
		Lead? leadByCpf = await _leadRepository.GetByCpfAsync(leadRequestDTO.CPF!);
		if (leadByCpf != null)
		{
			throw new LeadAlreadyExistsException(MessageKeyConstants.MESSAGE_ERROR_LEAD_CPF_ALREADY_EXISTS);
		}

		Lead? leadByEmail = await _leadRepository.GetByEmailAsync(leadRequestDTO.Email!);
		if (leadByEmail != null)
		{
			throw new LeadAlreadyExistsException(MessageKeyConstants.MESSAGE_ERROR_LEAD_EMAIL_ALREADY_EXISTS);
		}

		Lead lead = _mapperService.MapNewObject<Lead>(leadRequestDTO);
		await _leadRepository.AddAsync(lead);
		return _mapperService.MapNewObject<DetailLeadResponseDTO>(lead);
	}

	public async Task<UpdateLeadResponseDTO> UpdateLead(int leadId, UpdateLeadRequestDTO leadRequestDTO)
	{
		Lead? lead = await _leadRepository.GetByIdAsync(leadId);
		if (lead == null)
		{
			throw new LeadNotFoundException(MessageKeyConstants.MESSAGE_ERROR_LEAD_NOT_FOUND);
		}

		Lead? leadByEmail = await _leadRepository.GetByEmailAsync(leadRequestDTO.Email!);
		if (leadByEmail != null && leadByEmail.LeadId != leadId)
		{
			throw new LeadAlreadyExistsException(MessageKeyConstants.MESSAGE_ERROR_LEAD_EMAIL_ALREADY_EXISTS);
		}

		_mapperService.Map(leadRequestDTO, lead);
		await _leadRepository.UpdateAsync(lead);
		return _mapperService.MapNewObject<UpdateLeadResponseDTO>(lead);
	}

	public async Task<DetailLeadResponseDTO> GetLeadById(int leadId)
	{
		Lead? lead = await _leadRepository.GetByIdAsync(leadId);
		if (lead == null)
		{
			throw new LeadNotFoundException(MessageKeyConstants.MESSAGE_ERROR_LEAD_NOT_FOUND);
		}

		return _mapperService.MapNewObject<DetailLeadResponseDTO>(lead);
	}

	public async Task<IEnumerable<DetailLeadResponseDTO>> GetAllLeads()
	{
		IEnumerable<Lead> leads = await _leadRepository.GetAllAsync();
		return _mapperService.MapNewObject<IEnumerable<DetailLeadResponseDTO>>(leads);
	}

	public async Task<DeleteLeadResponseDTO> DeleteLead(int leadId)
	{
		Lead? lead = await _leadRepository.GetByIdAsync(leadId);
		if (lead == null)
		{
			throw new LeadNotFoundException(MessageKeyConstants.MESSAGE_ERROR_LEAD_NOT_FOUND);
		}

		await _leadRepository.DeleteAsync(lead);
		return _mapperService.MapNewObject<DeleteLeadResponseDTO>(lead);
	}
}
