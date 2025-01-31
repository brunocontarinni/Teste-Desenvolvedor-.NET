using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OfertaRepository : IBaseRepository<Oferta>
    {
        private readonly DataContext _context;

        public OfertaRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Oferta>> GetAllAsync() => await _context.Ofertas.ToListAsync();
        public async Task<Oferta> GetByIdAsync(int id) => await _context.Ofertas.FindAsync(id);
        public async Task<Oferta> AddAsync(Oferta oferta)
        {
            _context.Ofertas.Add(oferta);
            await _context.SaveChangesAsync();

            return oferta;
        }
        public async Task<bool> UpdateAsync(Oferta oferta)
        {
            bool status = _context.Entry(oferta).State.ToString() == "Modified";
            _context.Ofertas.Update(oferta);
            await _context.SaveChangesAsync();
            return status;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            bool status = false;
            var oferta = await GetByIdAsync(id);
            if (oferta != null)
            {
                _context.Ofertas.Remove(oferta);
                await _context.SaveChangesAsync();
                status = _context.Entry(oferta).State.ToString() == "Detached";
            }
            return status;
        }
    }
}
