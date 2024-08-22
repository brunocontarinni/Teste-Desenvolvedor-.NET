using Microsoft.EntityFrameworkCore;
using VestibularApi.Domain.Entities;
using VestibularApi.Domain.Repositories;
using VestibularApi.Infrastructure.Data;

namespace VestibularApi.Domain.Repositories.Implementations
{
    public class LeadRepository : ILeadRepository
    {
        private readonly ApplicationDbContext _context;

        public LeadRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LeadEntities> PegarPorIdAsync(Guid id)
        {
            return await _context.Leads.FindAsync(id);
        }

        public async Task<IEnumerable<LeadEntities>> PegarTodosAsync()
        {
            return await _context.Leads.ToListAsync();
        }

        public async Task AdicionarAsync(LeadEntities lead)
        {
            _context.Leads.Add(lead);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(LeadEntities lead)
        {
            _context.Leads.Update(lead);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(Guid id)
        {
            var lead = await PegarPorIdAsync(id);
            if (lead != null)
            {
                _context.Leads.Remove(lead);
                await _context.SaveChangesAsync();
            }
        }
    }
}
