using Microsoft.EntityFrameworkCore;
using VestibularApi.Domain.Entities;
using VestibularApi.Infrastructure.Data;

namespace VestibularApi.Domain.Repositories
{
    public class CandidatoRepository : ICandidatoRepository
    {
        private readonly ApplicationDbContext _context;

        public CandidatoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Candidato> PegarPorIdAsync(Guid id)
        {
            return await _context.Candidatos.FindAsync(id);
        }

        public async Task<IEnumerable<Candidato>> PegarTodosAsync()
        {
            return await _context.Candidatos.ToListAsync(); //ToListAsync();
        }

        public async Task AdicionarAsync(Candidato candidato)
        {
            await _context.Candidatos.AddAsync(candidato);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Candidato candidato)
        {
            _context.Candidatos.Update(candidato);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(Guid id)
        {
            var candidato = await _context.Candidatos.FindAsync(id);
            if (candidato != null)
            {
                _context.Candidatos.Remove(candidato);
                await _context.SaveChangesAsync();
            }
        }
    }
}
