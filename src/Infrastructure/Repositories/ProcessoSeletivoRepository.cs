using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProcessoSeletivoRepository : IBaseRepository<ProcessoSeletivo>
    {
        private readonly DataContext _context;

        public ProcessoSeletivoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProcessoSeletivo>> GetAllAsync() => await _context.ProcessosSeletivos.ToListAsync();
        public async Task<ProcessoSeletivo> GetByIdAsync(int id) => await _context.ProcessosSeletivos.FindAsync(id);
        public async Task<ProcessoSeletivo> AddAsync(ProcessoSeletivo processoSeletivo)
        {
            _context.ProcessosSeletivos.Add(processoSeletivo);
            await _context.SaveChangesAsync();
            return processoSeletivo;
        }
        public async Task<bool> UpdateAsync(ProcessoSeletivo processoSeletivo)
        {
            bool status = _context.Entry(processoSeletivo).State.ToString() == "Modified";
            _context.ProcessosSeletivos.Update(processoSeletivo);
            await _context.SaveChangesAsync();
            return status;

        }
        public async Task<bool> DeleteAsync(int id)
        {
            bool status = false;
            var processoSeletivo = await GetByIdAsync(id);
            if (processoSeletivo != null)
            {
                _context.ProcessosSeletivos.Remove(processoSeletivo);
                await _context.SaveChangesAsync();
                status = _context.Entry(processoSeletivo).State.ToString() == "Detached";
            }
            return status;
        }
    }
}
