using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CandidatoRepository : IBaseRepository<Candidato>
    {
        private readonly DataContext _context;

        public CandidatoRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Candidato>> GetAllAsync() => await _context.Candidatos.ToListAsync();
        public async Task<Candidato> GetByIdAsync(int id) => await _context.Candidatos.FindAsync(id);
        public async Task<Candidato> GetByCpfAsync(string cpf) => await _context.Candidatos.FirstOrDefaultAsync(c => c.Cpf == cpf);
        public async Task<Candidato> AddAsync(Candidato candidato)
        {
            _context.Candidatos.Add(candidato);
            await _context.SaveChangesAsync();
            return candidato;
        }
        public async Task<bool> UpdateAsync(Candidato candidato)
        {
            bool status = _context.Entry(candidato).State.ToString() == "Modified";
            _context.Candidatos.Update(candidato);
            await _context.SaveChangesAsync();
            return status;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            bool status = false;
            var candidato = await GetByIdAsync(id);
            if (candidato != null)
            {
                _context.Candidatos.Remove(candidato);
                await _context.SaveChangesAsync();
                status = _context.Entry(candidato).State.ToString() == "Detached";
                Console.Write(_context.Entry(candidato).State.ToString());
            }
            return status;
        }
    }
}
