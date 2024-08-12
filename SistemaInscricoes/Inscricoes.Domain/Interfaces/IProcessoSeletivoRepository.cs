using Inscricoes.Domain.Entities;

namespace Inscricoes.Domain.Interfaces;

public interface IProcessoSeletivoRepository : IBaseRepository<ProcessoSeletivo>
{
	Task<ProcessoSeletivo?> GetByNomeAsync(string nome);
	Task<ProcessoSeletivo?> GetByIdWithInscricoes(int processoSeletivoId);
}
