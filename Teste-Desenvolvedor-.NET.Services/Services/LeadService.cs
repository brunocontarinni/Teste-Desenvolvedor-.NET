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
            var lead = _mapper.Map<Lead>(model);
            var existe = await _dbContext.Leads.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(y => y.CPF == model.CPF);

            if (existe != null)
            {
                lead.AddNotificacao("CPF", "CPF já cadastrado");
            }

            if (lead.Notificacao.Any())
            {
                return lead;
            }

            await _dbContext.Leads.AddAsync(lead);
            await _dbContext.SaveChangesAsync();
            return lead;

        }

        public async Task<Lead> AtualizarLead(Guid id, LeadModel model)
        {
            var lead = _mapper.Map<Lead>(model);
            var existe = await _dbContext.Leads.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(y => y.Id == id);
            if (existe == null)
            {
                return null;
            }

            existe.Atualizar(lead.Nome, lead.Email, lead.Telefone, lead.CPF);

            if (existe.Notificacao.Any())
            {
                return existe;
            }

            _dbContext.Leads.Update(existe);
            await _dbContext.SaveChangesAsync();

            return existe;

        }

        public async Task<bool> DeletarLead(Guid id)
        {
            var lead = await _dbContext.Leads.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (lead == null)
            {
                return false;
            }

            lead.Delete();
            _dbContext.Leads.Update(lead);
            await _dbContext.SaveChangesAsync();

            return true;

        }

        public async Task<IEnumerable<Lead>> GetAllLead()
        {
            return await _dbContext.Leads.Where(x => x.Deleted == false).ToListAsync();
        }

        public Task<Lead> GetLead(Guid id)
        {
            return _dbContext.Leads.Where(x => x.Deleted == false).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
