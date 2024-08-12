using Inscricoes.Application.DTOs.ProcessoSeletivo;

namespace Inscricoes.Application.Interfaces;

public interface IProcessoSeletivoService
{
	Task<DetailProcessoSeletivoResponseDTO> CreateProcessoSeletivo(CreateProcessoSeletivoRequestDTO processoSeletivoRequestDTO);
	Task<UpdateProcessoSeletivoResponseDTO> UpdateProcessoSeletivo(int processoSeletivoId, UpdateProcessoSeletivoRequestDTO processoSeletivoRequestDTO);
	Task<DetailProcessoSeletivoResponseDTO> GetProcessoSeletivoById(int processoSeletivoId);
	Task<IEnumerable<DetailProcessoSeletivoResponseDTO>> GetAllProcessosSeletivos();
	Task<DeleteProcessoSeletivoResponseDTO> DeleteProcessoSeletivo(int processoSeletivoId);
}
