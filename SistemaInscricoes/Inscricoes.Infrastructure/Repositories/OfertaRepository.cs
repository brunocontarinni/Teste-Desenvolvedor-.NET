using Inscricoes.Domain.Entities;
using Inscricoes.Domain.Interfaces;
using Inscricoes.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Inscricoes.Infrastructure.Repositories;

public class OfertaRepository : BaseRepository<Oferta>, IOfertaRepository
{
	public OfertaRepository(AppDbContext context) : base(context)
	{
	}

	public async Task<Oferta?> GetByIdWithInscricoes(int ofertaId)
	{
		return await _context.Ofertas
			.Where(o => o.OfertaId == ofertaId)
			.Include(o => o.Inscricoes)
			.FirstOrDefaultAsync();
	}
}
