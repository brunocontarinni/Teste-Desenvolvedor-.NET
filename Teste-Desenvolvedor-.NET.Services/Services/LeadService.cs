using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Teste_Desenvolvedor_.NET.Data.Repositories;
using Teste_Desenvolvedor_.NET.Domain.Entities;
using Teste_Desenvolvedor_.NET.Models.Models;
using Teste_Desenvolvedor_.NET.Services.Interfaces;

namespace Teste_Desenvolvedor_.NET.Services.Services
{
    public class LeadService : ILeadService
    {
        private readonly IMapper _mapper;
        private readonly DBContext _dbContext;

        public LeadService(IMapper mapper, DBContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<Lead> AdicionarLead(LeadModel model)
        {
            //Mapeia o modelo para a Entidade de Dominio
            var lead = _mapper.Map<Lead>(model);

            // Verifica se o CPF ja esta cadastrado no banco de dados
            var existe = await _dbContext.Leads.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(y => y.CPF == model.CPF);

            // Caso sim adiciona uma notificação
            if (existe != null)
            {
                lead.AddNotificacao("CPF", "CPF já cadastrado");
            }

            // Caso tenha alguma notificação retorne
            if (lead.Notificacao.Any())
            {
                return lead;
            }

            // Salva o Lead no banco de dados
            await _dbContext.Leads.AddAsync(lead);
            await _dbContext.SaveChangesAsync();
            return lead;

        }

        public async Task<Lead> AtualizarLead(Guid id, LeadModel model)
        {
            // Mapeia o modelo para a Entidade de Dominio
            var lead = _mapper.Map<Lead>(model);

            //Procura o Lead no Banco de dados
            var existe = await _dbContext.Leads.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(y => y.Id == id);

            // Caso seja nulo retorne
            if (existe == null)
            {
                return null;
            }

            // Atualiza as propriedades do Lead
            existe.Atualizar(lead.Nome, lead.Email, lead.Telefone, lead.CPF);

            // Caso exista alguma notificação retorne
            if (existe.Notificacao.Any())
            {
                return existe;
            }

            //Atualiza o Lead no banco de dados
            _dbContext.Leads.Update(existe);
            await _dbContext.SaveChangesAsync();

            return existe;

        }

        public async Task<bool> DeletarLead(Guid id)
        {
            // Procura o Lead no banco de dados
            var lead = await _dbContext.Leads.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(x => x.Id == id);
            
            // Caso for nulo retorne nulo
            if (lead == null)
            {
                return false;
            }

            // Atualiza a flag de deleção para true 
            lead.Delete();

            // Atualiza no banco de dados
            _dbContext.Leads.Update(lead);
            await _dbContext.SaveChangesAsync();

            return true;

        }

        public async Task<IEnumerable<Lead>> GetAllLead()
        {
            // Retorna todos os Leads que nao foram Deletados
            return await _dbContext.Leads.Where(x => x.Deleted == false).ToListAsync();
        }

        public Task<Lead> GetLead(Guid id)
        {
            // retorna um Lead que nao foi Deletado
            return _dbContext.Leads.Where(x => x.Deleted == false).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
