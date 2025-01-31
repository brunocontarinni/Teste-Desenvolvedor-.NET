using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class InscricaoRepository : IBaseRepository<Inscricao>
    {
        private readonly DataContext _context;

        public InscricaoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Inscricao>> GetAllAsync() => await _context.Inscricoes.Include(i => i.Candidato).Include(i => i.Oferta).Include(i => i.ProcessoSeletivo).Include(i => i.Oferta).ToListAsync();
        public async Task<Inscricao> GetByIdAsync(int id) => await _context.Inscricoes.Include(i => i.Candidato).Include(i => i.Oferta).Include(i => i.ProcessoSeletivo).FirstOrDefaultAsync(i => i.Id == id);
        public async Task<IEnumerable<Inscricao>> GetByCpfAsync(string cpf) => 
            await _context.Inscricoes.Include(i => i.Candidato)
                .Include(i => i.Oferta)
                .Include(i => i.ProcessoSeletivo)
                .Where(i => i.Candidato.Cpf == cpf).ToListAsync();

        public async Task<IEnumerable<Inscricao>> GetByIdOfertaAsync(int id) => 
            await _context.Inscricoes.Include(i => i.Candidato)
                .Include(i => i.Oferta)
                .Include(i => i.ProcessoSeletivo)
                .Where(i => i.Oferta.Id == id).ToListAsync();
            
        public async Task<IEnumerable<Inscricao>> GetByOfertaIdAsync(int ofertaId) => 
            await _context.Inscricoes.Include(i => i.Candidato).Include(i => i.Oferta)
            .Where(i => i.Oferta.Id == ofertaId).ToListAsync();

        public async Task<Inscricao> AddAsync(Inscricao inscricao)
        {
            
            _context.Entry(inscricao.Candidato).State = EntityState.Unchanged;
            _context.Entry(inscricao.ProcessoSeletivo).State = EntityState.Unchanged;
            _context.Entry(inscricao.Oferta).State = EntityState.Unchanged;

            _context.Inscricoes.Add(inscricao);
            await _context.SaveChangesAsync();
            return inscricao;
        }
        public async Task<bool> UpdateAsync(Inscricao inscricao)
        {
            bool status = _context.Entry(inscricao).State.ToString() == "Modified";
            
            _context.Inscricoes.Update(inscricao);
            await _context.SaveChangesAsync();
            return status;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            bool status = false;
            var inscricao = await GetByIdAsync(id);
            if (inscricao != null)
            {
                _context.Inscricoes.Remove(inscricao);
                await _context.SaveChangesAsync();
                status = _context.Entry(inscricao).State.ToString() == "Detached";
            }
            return status;
        }
    }
}
