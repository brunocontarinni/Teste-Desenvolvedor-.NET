using Inscricoes.Application.DTOs.Inscricao;
using Inscricoes.Application.Interfaces;
using Inscricoes.Domain.Entities;
using Inscricoes.Domain.Interfaces;
using Inscricoes.Shared.Exceptions;
using Inscricoes.Shared.Constants;

namespace Inscricoes.Application.Services;

public class InscricaoService : IInscricaoService
{
	private readonly IInscricaoRepository _inscricaoRepository;
	private readonly IProcessoSeletivoRepository _processoSeletivoRepository;
	private readonly IOfertaRepository _ofertaRepository;
	private readonly IMapperService _mapperService;

	public InscricaoService(IInscricaoRepository inscricaoRepository, IProcessoSeletivoRepository processoSeletivoRepository, IOfertaRepository ofertaRepository, IMapperService mapperService)
	{
		_inscricaoRepository = inscricaoRepository;
		_processoSeletivoRepository = processoSeletivoRepository;
		_ofertaRepository = ofertaRepository;
		_mapperService = mapperService;
	}

	public async Task<CreateInscricaoResponseDTO> CreateInscricao(CreateInscricaoRequestDTO inscricaoRequestDTO)
	{
		DateTime dateTime = DateTime.UtcNow;
		ProcessoSeletivo? processoSeletivo = await _processoSeletivoRepository.GetByIdAsync(inscricaoRequestDTO.ProcessoSeletivoId);
		if (processoSeletivo == null)
		{
			throw new ProcessoSeletivoNotFoundException(MessageKeyConstants.MESSAGE_ERROR_PROCESSO_SELETIVO_NOT_FOUND);
		}
		if (dateTime < processoSeletivo.DataInicio || dateTime > processoSeletivo.DataTermino)
		{
			throw new ProcessoSeletivoException(MessageKeyConstants.MESSAGE_ERROR_PROCESSO_SELETIVO_NOT_OPEN);
		}

		Oferta? oferta = await _ofertaRepository.GetByIdAsync(inscricaoRequestDTO.OfertaId);
		if (oferta == null)
		{
			throw new OfertaNotFoundException(MessageKeyConstants.MESSAGE_ERROR_OFERTA_NOT_FOUND);
		}
		if (oferta.VagasDisponiveis <= 0)
		{
			throw new OfertaException(MessageKeyConstants.MERSSAGE_ERROR_OFERTA_NO_VACANCIES);
		}

		IEnumerable<Inscricao> existingInscricao = await _inscricaoRepository.GetAllAsync();
		if (existingInscricao.Any(i =>
			i.LeadId == inscricaoRequestDTO.LeadId &&
			i.ProcessoSeletivoId == inscricaoRequestDTO.ProcessoSeletivoId &&
			i.OfertaId == inscricaoRequestDTO.OfertaId))
		{
			throw new InscricaoAlreadyExistsException(MessageKeyConstants.MESSAGE_ERROR_INSCRICAO_ALREADY_EXISTS);
		}

		Inscricao inscricao = _mapperService.MapNewObject<Inscricao>(inscricaoRequestDTO);
		await _inscricaoRepository.AddAsync(inscricao);
		oferta.VagasDisponiveis -= 1;
		inscricao.GerarNumeroInscricao();

		await _inscricaoRepository.UpdateAsync(inscricao);
		return _mapperService.MapNewObject<CreateInscricaoResponseDTO>(inscricao);
	}

	public async Task<UpdateInscricaoResponseDTO> UpdateInscricao(int inscricaoId, UpdateInscricaoRequestDTO inscricaoRequestDTO)
	{
		Inscricao? inscricao = await _inscricaoRepository.GetByIdAsync(inscricaoId);
		if (inscricao == null)
		{
			throw new InscricaoNotFoundException(MessageKeyConstants.MESSAGE_ERROR_INSCRICAO_NOT_FOUND);
		}

		_mapperService.Map(inscricaoRequestDTO, inscricao);
		await _inscricaoRepository.UpdateAsync(inscricao);
		return _mapperService.MapNewObject<UpdateInscricaoResponseDTO>(inscricao);
	}

	public async Task<DetailInscricaoResponseDTO> GetInscricaoById(int inscricaoId)
	{
		Inscricao? inscricao = await _inscricaoRepository.GetByIdAsync(inscricaoId);
		if (inscricao == null)
		{
			throw new InscricaoNotFoundException(MessageKeyConstants.MESSAGE_ERROR_INSCRICAO_NOT_FOUND);
		}

		return _mapperService.MapNewObject<DetailInscricaoResponseDTO>(inscricao);
	}

	public async Task<IEnumerable<DetailInscricaoResponseDTO>> GetAllInscricoes()
	{
		IEnumerable<Inscricao> inscricoes = await _inscricaoRepository.GetAllAsync();

		return _mapperService.MapNewObject<IEnumerable<DetailInscricaoResponseDTO>>(inscricoes);
	}

	public async Task<IEnumerable<DetailInscricaoProcessoResponseDTO>> GetInscricoesByCpf(string cpf)
	{
		IEnumerable<Inscricao> inscricoes = await _inscricaoRepository.GetByCpfAsync(cpf);

		return _mapperService.MapNewObject<IEnumerable<DetailInscricaoProcessoResponseDTO>>(inscricoes);
	}

	public async Task<IEnumerable<DetailInscricaoResponseDTO>> GetInscricoesByOfertaId(int ofertaId)
	{
		IEnumerable<Inscricao> inscricoes = await _inscricaoRepository.GetByOfertaIdAsync(ofertaId);

		return _mapperService.MapNewObject<IEnumerable<DetailInscricaoResponseDTO>>(inscricoes);
	}

	public async Task<DeleteInscricaoResponseDTO> DeleteInscricao(int inscricaoId)
	{
		Inscricao? inscricao = await _inscricaoRepository.GetByIdAsync(inscricaoId);
		if (inscricao == null)
		{
			throw new InscricaoNotFoundException(MessageKeyConstants.MESSAGE_ERROR_INSCRICAO_NOT_FOUND);
		}

		await _inscricaoRepository.DeleteAsync(inscricao);
		return _mapperService.MapNewObject<DeleteInscricaoResponseDTO>(inscricao);
	}
}
