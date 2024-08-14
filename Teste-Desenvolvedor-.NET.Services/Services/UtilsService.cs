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
            // Retorna uma Lista de Isncrições que foram deletadas
            return await _dbContext.Inscricoes
                .Include(x => x.Oferta)
                .Include(x => x.Lead)
                .Include(x => x.ProcessoSeletivo)
                .Where(x => x.Deleted == true).ToListAsync();
        }

        public async Task<IEnumerable<Lead>> GetAllDeletedLeads()
        {
            // Retorna uma lista de Leads deletados
            return await _dbContext.Leads.Where(x => x.Deleted == true).ToListAsync();
        }

        public async Task<IEnumerable<Oferta>> GetAllDeletedOferta()
        {
            // Retorna uma lista de Ofertas deletadas
            return await _dbContext.Ofertas.Where(x => x.Deleted == true).ToListAsync();
        }

        public async Task<IEnumerable<ProcessoSeletivo>> GetAllDeletedProcessoSeletivo()
        {
            // Retorna uma lista de Processos Seletivos deleatados
            return await _dbContext.ProcessosSeletivos.Where(x => x.Deleted == true).ToListAsync();
        }

        // Função para deletar permanentimente uma entidade do banco de dados
        public async Task<bool> Deletar(Guid id)
        {
            // Procura o ID no banco de dadaos
            var inscricao = await _dbContext.Inscricoes.FirstOrDefaultAsync(x => x.Id == id);
            var lead = await _dbContext.Leads.FirstOrDefaultAsync(x => x.Id == id);
            var oferta = await _dbContext.Ofertas.FirstOrDefaultAsync(x => x.Id == id);
            var processo = await _dbContext.ProcessosSeletivos.FirstOrDefaultAsync(x => x.Id == id);

            // Remove a Entidade do banco de dados e retorna true
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
