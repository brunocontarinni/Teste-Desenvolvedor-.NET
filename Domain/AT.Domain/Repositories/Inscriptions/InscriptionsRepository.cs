using AT.Domain.Entities;
using AT.Domain.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace AT.Domain.Repositories.Inscriptions
{
    public class InscriptionsRepository(AppDbContext context) : IInscriptionsRepository
    {
        private readonly AppDbContext _context = context;

        public async Task CreateAsync(Inscription entity)
        {
            _context.Inscriptions.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var inscriptions = await GetAsync(id);

            if (inscriptions != null)
            {
                _context.Inscriptions.Remove(inscriptions);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Inscription?> GetAsync(long id)
        {
            var inscriptions = await _context.Inscriptions.Include(i => i.Candidate)
                                                          .Include(i => i.Course)
                                                          .Include(i => i.SelectionProcess)
                                                          .FirstOrDefaultAsync(x => x.Id == id);
            return inscriptions;
        }

        public async Task<IEnumerable<Inscription>> GetAllAsync()
        {
            var inscriptions = await _context.Inscriptions.Include(i => i.Candidate)
                                                          .Include(i => i.Course)
                                                          .Include(i => i.SelectionProcess)
                                                          .ToListAsync();
            return inscriptions;
        }

        public async Task UpdateAsync(Inscription entity)
        {
            _context.Inscriptions.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}