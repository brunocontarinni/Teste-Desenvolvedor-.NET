using Inscricoes.Domain.Entities;
using Inscricoes.Domain.Interfaces;
using Inscricoes.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Inscricoes.Infrastructure.Repositories;

public class ProcessoSeletivoRepository : BaseRepository<ProcessoSeletivo>, IProcessoSeletivoRepository
{
	public ProcessoSeletivoRepository(AppDbContext context) : base(context)
	{
	}

	public async Task<ProcessoSeletivo?> GetByNomeAsync(string nome)
	{
		return await _context.ProcessosSeletivos
			.AsNoTracking()
			.FirstOrDefaultAsync(l => l.Nome == nome);
	}

	public async Task<ProcessoSeletivo?> GetByIdWithInscricoes(int processoSeletivoId)
	{
		return await _context.ProcessosSeletivos
			.Where(p => p.ProcessoSeletivoId == processoSeletivoId)
			.Include(p => p.Inscricoes)
			.AsNoTracking()
			.FirstOrDefaultAsync();
	}
}
