using Microsoft.EntityFrameworkCore;
using VestibularApi.Domain.Entities;
using VestibularApi.Domain.Repositories.Interfaces;
using VestibularApi.Infrastructure.Data;

namespace VestibularApi.Domain.Repositories.Implementations
{
    public class OfertaRepository : IOfertaRepository
    {
        private readonly ApplicationDbContext _context;

        public OfertaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<OfertaEntities>> PegarTodasAsync()
        {
            return await _context.Ofertas.ToListAsync();
        }

        public async Task<OfertaEntities> PegarPorIdAsync(Guid id)
        {
            return await _context.Ofertas.FindAsync(id);
        }

        public async Task AdicionarAsync(OfertaEntities oferta)
        {
            await _context.Ofertas.AddAsync(oferta);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(OfertaEntities oferta)
        {
            _context.Ofertas.Update(oferta);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(Guid id)
        {
            var oferta = await PegarPorIdAsync(id);

            if (oferta != null)
            {
                _context.Ofertas.Remove(oferta);
                await _context.SaveChangesAsync();
            }
        }
    }
}
