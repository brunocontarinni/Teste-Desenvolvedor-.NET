using Microsoft.EntityFrameworkCore;
using VestibularApi.Domain.Entities;
using VestibularApi.Domain.Repositories;
using VestibularApi.Infrastructure.Data;

namespace VestibularApi.Domain.Repositories.Implementations
{
    public class ProcessoSeletivoRepository : IProcessoSeletivoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProcessoSeletivoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProcessoSeletivoEntities> PegarPorIdAsync(Guid id)
        {
            return await _context.ProcessosSeletivos.FindAsync(id);
        }

        public async Task<IEnumerable<ProcessoSeletivoEntities>> PegarTodosAsync()
        {
            return await _context.ProcessosSeletivos.ToListAsync();
        }

        public async Task AdicionarAsync(ProcessoSeletivoEntities processoSeletivo)
        {
            _context.ProcessosSeletivos.Add(processoSeletivo);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(ProcessoSeletivoEntities processoSeletivo)
        {
            _context.ProcessosSeletivos.Update(processoSeletivo);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(Guid id)
        {
            var processoSeletivo = await PegarPorIdAsync(id);
            if (processoSeletivo != null)
            {
                _context.ProcessosSeletivos.Remove(processoSeletivo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
