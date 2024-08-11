using Inscricoes.Domain.Entities;
using Inscricoes.Domain.Interfaces;
using Inscricoes.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Inscricoes.Infrastructure.Repositories;

public class LeadRepository : BaseRepository<Lead>, ILeadRepository
{
	public LeadRepository(AppDbContext context) : base(context)
	{
	}

	public async Task<Lead?> GetByCpfAsync(string cpf)
	{
		return await _context.Leads
			.AsNoTracking()
			.FirstOrDefaultAsync(l => l.CPF == cpf);
	}

	public async Task<Lead?> GetByEmailAsync(string email)
	{
		return await _context.Leads
			.AsNoTracking()
			.FirstOrDefaultAsync(l => l.Email == email);
	}
}
