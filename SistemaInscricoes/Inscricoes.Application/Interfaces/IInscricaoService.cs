using Inscricoes.Application.DTOs.Inscricao;

namespace Inscricoes.Application.Interfaces;

public interface IInscricaoService
{
	Task<CreateInscricaoResponseDTO> CreateInscricao(CreateInscricaoRequestDTO inscricaoRequestDTO);
	Task<UpdateInscricaoResponseDTO> UpdateInscricao(int inscricaoId, UpdateInscricaoRequestDTO inscricaoRequestDTO);
	Task<DetailInscricaoResponseDTO> GetInscricaoById(int inscricaoId);
	Task<IEnumerable<DetailInscricaoResponseDTO>> GetAllInscricoes();
	Task<IEnumerable<DetailInscricaoProcessoResponseDTO>> GetInscricoesByCpf(string cpf);
	Task<IEnumerable<DetailInscricaoResponseDTO>> GetInscricoesByOfertaId(int ofertaId);
	Task<DeleteInscricaoResponseDTO> DeleteInscricao(int inscricaoId);
}
