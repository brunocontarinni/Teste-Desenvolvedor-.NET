using Microsoft.EntityFrameworkCore;
using VestibularApi.Domain.Entities;
using VestibularApi.Domain.Repositories.Interfaces;
using VestibularApi.Infrastructure.Data;


namespace VestibularApi.Infrastructure.Repositories
{
    public class InscricaoRepository : IInscricaoRepository
    {
        private readonly ApplicationDbContext _contexto;

        public InscricaoRepository(ApplicationDbContext contexto)
        {
            _contexto = contexto;
        }

        public async Task<InscricaoEntities> PegarPorIdAsync(Guid id)
        {
            return await _contexto.Inscricoes.FindAsync(id);
        }

        public async Task<IEnumerable<InscricaoEntities>> PegarTodasAsync()
        {
            return await _contexto.Inscricoes.ToListAsync();
        }

        public async Task AdicionarAsync(InscricaoEntities inscricao)
        {
            await _contexto.Inscricoes.AddAsync(inscricao);
            await _contexto.SaveChangesAsync();
        }

        public async Task AtualizarAsync(InscricaoEntities inscricao)
        {
            _contexto.Inscricoes.Update(inscricao);
            await _contexto.SaveChangesAsync();
        }

        public async Task DeletarAsync(Guid id)
        {
            var inscricao = await _contexto.Inscricoes.FindAsync(id);
            if (inscricao != null)
            {
                _contexto.Inscricoes.Remove(inscricao);
                await _contexto.SaveChangesAsync();
            }
        }
    }
}
