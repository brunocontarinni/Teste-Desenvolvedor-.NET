using AT.Domain.Entities;
using AT.Domain.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace AT.Domain.Repositories.SelectionProcesses
{
    public class SelectionProcessesRepository(AppDbContext context) : ISelectionProcessesRepository
    {
        private readonly AppDbContext _context = context;

        public async Task CreateAsync(SelectionProcess entity)
        {
            _context.SelectionProcesses.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var selectionProcesses = await GetAsync(id);

            if (selectionProcesses != null)
            {
                _context.SelectionProcesses.Remove(selectionProcesses);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<SelectionProcess?> GetAsync(long id)
        {
            var selectionProcesses = await _context.SelectionProcesses.FirstOrDefaultAsync(x => x.Id == id);
            return selectionProcesses;
        }

        public async Task<IEnumerable<SelectionProcess>> GetAllAsync()
        {
            var selectionProcesses = await _context.SelectionProcesses.ToListAsync();
            return selectionProcesses;
        }

        public async Task UpdateAsync(SelectionProcess entity)
        {
            _context.SelectionProcesses.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}