using Microsoft.EntityFrameworkCore;
using VestibularApi.Domain.Entities;
using VestibularApi.Domain.Repositories.Interfaces;
using VestibularApi.Infrastructure.Data;

namespace VestibularApi.Domain.Repositories.Implementations
{
    public class InscricaoRepository : IInscricaoRepository
    {
        private readonly ApplicationDbContext _context;

        public InscricaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<InscricaoEntities> PegarPorIdAsync(Guid id)
        {
            return await _context.Inscricoes.FindAsync(id);
        }

        public async Task<IEnumerable<InscricaoEntities>> PegarTodasAsync()
        {
            return await _context.Inscricoes.ToListAsync();
        }

        public async Task AdicionarAsync(InscricaoEntities inscricao)
        {
            _context.Inscricoes.Add(inscricao);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(InscricaoEntities inscricao)
        {
            _context.Inscricoes.Update(inscricao);
            await _context.SaveChangesAsync();
        }

        public async Task DeletarAsync(Guid id)
        {
            var inscricao = await PegarPorIdAsync(id);
            if (inscricao != null)
            {
                _context.Inscricoes.Remove(inscricao);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<InscricaoEntities>> PegarPorCpfAsync(string cpf)
        {
            return await _context.Inscricoes
                .Include(i => i.Candidato)
                .Include(i => i.Oferta)
                .Where(i => i.Candidato.CPF == cpf)
                .ToListAsync();
        }

        public async Task<IEnumerable<InscricaoEntities>> PegarPorOfertaAsync(Guid ofertaId)
        {
            return await _context.Inscricoes
                .Include(i => i.Candidato)
                .Include(i => i.Oferta)
                .Where(i => i.OfertaId == ofertaId)
                .ToListAsync();
        }
    }
}
