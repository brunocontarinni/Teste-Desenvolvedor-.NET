using AT.Domain.Entities;
using AT.Domain.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace AT.Domain.Repositories.Candidates
{
    public class CandidatesRepository(AppDbContext context) : ICandidatesRepository
    {
        private readonly AppDbContext _context = context;

        public async Task CreateAsync(Candidate entity)
        {
            _context.Candidates.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var candidates = await GetAsync(id);

            if (candidates != null)
            {
                _context.Candidates.Remove(candidates);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Candidate?> GetAsync(long id)
        {
            var candidates = await _context.Candidates.FirstOrDefaultAsync(x => x.Id == id);
            return candidates;
        }

        public async Task<IEnumerable<Candidate>> GetAllAsync()
        {
            var candidates = await _context.Candidates.ToListAsync();
            return candidates;
        }

        public async Task UpdateAsync(Candidate entity)
        {
            _context.Candidates.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}