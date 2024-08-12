using Inscricoes.Application.DTOs.ProcessoSeletivo;
using Inscricoes.Application.Interfaces;
using Inscricoes.Domain.Entities;
using Inscricoes.Domain.Interfaces;
using Inscricoes.Shared.Exceptions;
using Inscricoes.Shared.Constants;

namespace Inscricoes.Application.Services;

public class ProcessoSeletivoService : IProcessoSeletivoService
{
	private readonly IProcessoSeletivoRepository _processoSeletivoRepository;
	private readonly IMapperService _mapperService;

	public ProcessoSeletivoService(IProcessoSeletivoRepository processoSeletivoRepository, IMapperService mapperService)
	{
		_processoSeletivoRepository = processoSeletivoRepository;
		_mapperService = mapperService;
	}

	public async Task<DetailProcessoSeletivoResponseDTO> CreateProcessoSeletivo(CreateProcessoSeletivoRequestDTO processoSeletivoRequestDTO)
	{
		DateTime dateTime = DateTime.UtcNow;
		ProcessoSeletivo? processoSeletivoByNome = await _processoSeletivoRepository.GetByNomeAsync(processoSeletivoRequestDTO.Nome!);
		if (processoSeletivoByNome != null)
		{
			throw new ProcessoSeletivoAlreadyExistsException(MessageKeyConstants.MESSAGE_ERROR_PROCESSO_SELETIVO_ALREADY_EXISTS);
		}
		if (processoSeletivoRequestDTO.DataInicio < dateTime || processoSeletivoRequestDTO.DataInicio >= processoSeletivoRequestDTO.DataTermino)
		{
			throw new ProcessoSeletivoException(MessageKeyConstants.MESSAGE_ERROR_PROCESSO_SELETIVO_DATE_INVALID);
		}

		ProcessoSeletivo processoSeletivo = _mapperService.MapNewObject<ProcessoSeletivo>(processoSeletivoRequestDTO);
		await _processoSeletivoRepository.AddAsync(processoSeletivo);
		return _mapperService.MapNewObject<DetailProcessoSeletivoResponseDTO>(processoSeletivo);
	}

	public async Task<UpdateProcessoSeletivoResponseDTO> UpdateProcessoSeletivo(int processoSeletivoId, UpdateProcessoSeletivoRequestDTO processoSeletivoRequestDTO)
	{
		ProcessoSeletivo? processoSeletivo = await _processoSeletivoRepository.GetByIdAsync(processoSeletivoId);
		if (processoSeletivo == null)
		{
			throw new ProcessoSeletivoNotFoundException(MessageKeyConstants.MESSAGE_ERROR_PROCESSO_SELETIVO_NOT_FOUND);
		}

		ProcessoSeletivo? processoSeletivoByNome = await _processoSeletivoRepository.GetByNomeAsync(processoSeletivoRequestDTO.Nome!);
		if (processoSeletivoByNome != null)
		{
			throw new ProcessoSeletivoAlreadyExistsException(MessageKeyConstants.MESSAGE_ERROR_PROCESSO_SELETIVO_ALREADY_EXISTS);
		}

		_mapperService.Map(processoSeletivoRequestDTO, processoSeletivo);
		await _processoSeletivoRepository.UpdateAsync(processoSeletivo);
		return _mapperService.MapNewObject<UpdateProcessoSeletivoResponseDTO>(processoSeletivo);
	}

	public async Task<DetailProcessoSeletivoResponseDTO> GetProcessoSeletivoById(int processoSeletivoId)
	{
		ProcessoSeletivo? processoSeletivo = await _processoSeletivoRepository.GetByIdAsync(processoSeletivoId);
		if (processoSeletivo == null)
		{
			throw new ProcessoSeletivoNotFoundException(MessageKeyConstants.MESSAGE_ERROR_PROCESSO_SELETIVO_NOT_FOUND);
		}

		return _mapperService.MapNewObject<DetailProcessoSeletivoResponseDTO>(processoSeletivo);
	}

	public async Task<IEnumerable<DetailProcessoSeletivoResponseDTO>> GetAllProcessosSeletivos()
	{
		IEnumerable<ProcessoSeletivo> processosSeletivos = await _processoSeletivoRepository.GetAllAsync();
		return _mapperService.MapNewObject<IEnumerable<DetailProcessoSeletivoResponseDTO>>(processosSeletivos);
	}

	public async Task<DeleteProcessoSeletivoResponseDTO> DeleteProcessoSeletivo(int processoSeletivoId)
	{
		ProcessoSeletivo? processoSeletivo = await _processoSeletivoRepository.GetByIdWithInscricoes(processoSeletivoId);
		if (processoSeletivo == null)
		{
			throw new ProcessoSeletivoNotFoundException(MessageKeyConstants.MESSAGE_ERROR_PROCESSO_SELETIVO_NOT_FOUND);
		}

		if (processoSeletivo.Inscricoes.Any())
		{
			throw new ProcessoSeletivoException(MessageKeyConstants.MESSAGE_ERROR_PROCESSO_SELETIVO_HAS_INSCRICOES);
		}

		await _processoSeletivoRepository.DeleteAsync(processoSeletivo);
		return _mapperService.MapNewObject<DeleteProcessoSeletivoResponseDTO>(processoSeletivo);
	}
}
