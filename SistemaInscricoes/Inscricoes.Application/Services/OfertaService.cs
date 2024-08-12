using Inscricoes.Application.DTOs.Oferta;
using Inscricoes.Application.Interfaces;
using Inscricoes.Domain.Entities;
using Inscricoes.Domain.Interfaces;
using Inscricoes.Shared.Exceptions;
using Inscricoes.Shared.Constants;

namespace Inscricoes.Application.Services;

public class OfertaService : IOfertaService
{
	private readonly IOfertaRepository _ofertaRepository;
	private readonly IMapperService _mapperService;

	public OfertaService(IOfertaRepository ofertaRepository, IMapperService mapperService)
	{
		_ofertaRepository = ofertaRepository;
		_mapperService = mapperService;
	}

	public async Task<DetailOfertaResponseDTO> CreateOferta(CreateOfertaRequestDTO ofertaRequestDTO)
	{
		Oferta oferta = _mapperService.MapNewObject<Oferta>(ofertaRequestDTO);
		await _ofertaRepository.AddAsync(oferta);
		return _mapperService.MapNewObject<DetailOfertaResponseDTO>(oferta);
	}

	public async Task<UpdateOfertaResponseDTO> UpdateOferta(int ofertaId, UpdateOfertaRequestDTO ofertaRequestDTO)
	{
		Oferta? oferta = await _ofertaRepository.GetByIdAsync(ofertaId);
		if (oferta == null)
		{
			throw new OfertaNotFoundException(MessageKeyConstants.MESSAGE_ERROR_OFERTA_NOT_FOUND);
		}

		_mapperService.Map(ofertaRequestDTO, oferta);
		await _ofertaRepository.UpdateAsync(oferta);
		return _mapperService.MapNewObject<UpdateOfertaResponseDTO>(oferta);
	}

	public async Task<DetailOfertaResponseDTO> GetOfertaById(int ofertaId)
	{
		Oferta? oferta = await _ofertaRepository.GetByIdAsync(ofertaId);
		if (oferta == null)
		{
			throw new OfertaNotFoundException(MessageKeyConstants.MESSAGE_ERROR_OFERTA_NOT_FOUND);
		}

		return _mapperService.MapNewObject<DetailOfertaResponseDTO>(oferta);
	}

	public async Task<IEnumerable<DetailOfertaResponseDTO>> GetAllOfertas()
	{
		IEnumerable<Oferta> ofertas = await _ofertaRepository.GetAllAsync();
		return _mapperService.MapNewObject<IEnumerable<DetailOfertaResponseDTO>>(ofertas);
	}

	public async Task<DeleteOfertaResponseDTO> DeleteOferta(int ofertaId)
	{
		Oferta? oferta = await _ofertaRepository.GetByIdWithInscricoes(ofertaId);
		if (oferta == null)
		{
			throw new OfertaNotFoundException(MessageKeyConstants.MESSAGE_ERROR_OFERTA_NOT_FOUND);
		}

		if (oferta.Inscricoes.Any())
		{
			throw new OfertaException(MessageKeyConstants.MESSAGE_ERROR_OFERTA_HAS_INSCRICOES);
		}

		await _ofertaRepository.DeleteAsync(oferta);
		return _mapperService.MapNewObject<DeleteOfertaResponseDTO>(oferta);
	}
}
