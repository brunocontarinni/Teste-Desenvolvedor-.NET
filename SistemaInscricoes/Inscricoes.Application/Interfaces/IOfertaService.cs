using Inscricoes.Application.DTOs.Oferta;

namespace Inscricoes.Application.Interfaces;

public interface IOfertaService
{
	Task<DetailOfertaResponseDTO> CreateOferta(CreateOfertaRequestDTO ofertaRequestDTO);
	Task<UpdateOfertaResponseDTO> UpdateOferta(int ofertaId, UpdateOfertaRequestDTO ofertaRequestDTO);
	Task<DetailOfertaResponseDTO> GetOfertaById(int ofertaId);
	Task<IEnumerable<DetailOfertaResponseDTO>> GetAllOfertas();
	Task<DeleteOfertaResponseDTO> DeleteOferta(int ofertaId);
}
