using Microsoft.EntityFrameworkCore;
using Teste_Desenvolvedor_.NET.Data.Repositories;
using Teste_Desenvolvedor_.NET.Domain.Entities;
using Teste_Desenvolvedor_.NET.Services.Interfaces;

namespace Teste_Desenvolvedor_.NET.Services.Services
{
    public class UtilsService : IUtilsService
    {
        private readonly DBContext _dbContext;

        public UtilsService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Inscricao>> GetAllDeletedInscricoes()
        {
            return await _dbContext.Inscricoes.Include(x => x.Oferta)
                .Include(x => x.Lead)
                .Include(x => x.ProcessoSeletivo)
                .Where(x => x.Deleted == true).ToListAsync();
        }

        public async Task<IEnumerable<Lead>> GetAllDeletedLeads()
        {
            return await _dbContext.Leads.Where(x => x.Deleted == true).ToListAsync();
        }

        public async Task<IEnumerable<Oferta>> GetAllDeletedOferta()
        {
            return await _dbContext.Ofertas.Where(x => x.Deleted == true).ToListAsync();
        }

        public async Task<IEnumerable<ProcessoSeletivo>> GetAllDeletedProcessoSeletivo()
        {
            return await _dbContext.ProcessosSeletivos.Where(x => x.Deleted == true).ToListAsync();
        }


        public async Task<bool> Deletar(Guid id)
        {
            var inscricao = await _dbContext.Inscricoes.FirstOrDefaultAsync(x => x.Id == id);
            var lead = await _dbContext.Leads.FirstOrDefaultAsync(x => x.Id == id);
            var oferta = await _dbContext.Ofertas.FirstOrDefaultAsync(x => x.Id == id);
            var processo = await _dbContext.ProcessosSeletivos.FirstOrDefaultAsync(x => x.Id == id);

            if (inscricao != null)
            {
                _dbContext.Inscricoes.Remove(inscricao);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else if (lead != null)
            {
                _dbContext.Leads.Remove(lead);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else if (oferta != null)
            {
                _dbContext.Ofertas.Remove(oferta);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            else if (processo != null)
            {
                _dbContext.ProcessosSeletivos.Remove(processo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
           
                return false;

        }


    }
}
