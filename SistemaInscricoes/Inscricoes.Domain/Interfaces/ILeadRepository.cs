using Inscricoes.Domain.Entities;

namespace Inscricoes.Domain.Interfaces;

public interface ILeadRepository : IBaseRepository<Lead>
{
	Task<Lead?> GetByCpfAsync(string cpf);
	Task<Lead?> GetByEmailAsync(string email);
}
