using AutoMapper;
using CrmTest.AppDataContext;
using CrmTest.DTO;
using CrmTest.Interface;
using CrmTest.Models;
using Microsoft.EntityFrameworkCore;
namespace CrmTest.Services{
    public class LeadServices : ILeadServices
    {
        private readonly CrmTestDbContex _context;
        private readonly ILogger<LeadServices> _logger;
        private readonly IMapper _mapper;

        public LeadServices(CrmTestDbContex context, ILogger<LeadServices> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task CreateLead(Lead request)
        {
            try{
                var leadMapping = _mapper.Map<Lead>(request);
                _context.Lead.Add(leadMapping);
                await _context.SaveChangesAsync();
            }catch(Exception e){
                _logger.LogError(e, "Ocorreu um erro ao criar Lead.");
                throw new Exception("Ocorreu um erro ao criar Lead");
            }
        }

        public async Task DeleteLead(int id)
        {
            var leadMap = await _context.Lead.FindAsync(id);
            if (leadMap != null)
            {
                _context.Lead.Remove(leadMap);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Lead de Id-{id} não encontrado.");
            }
        }

        public async Task<IEnumerable<Lead>> GetAllLeads()
        {
            var leadMapping= await _context.Lead.ToListAsync();
            if (leadMapping == null)
            {
                throw new Exception("Sem leads encontrados");
            }
            return leadMapping;
        }

        public async Task<Lead> GetLeadById(int id)
        {
            var leadMap = await _context.Lead.FindAsync(id);
            if (leadMap == null)
                throw new Exception("Lead não encontrado.");
            return leadMap;
        }

        public async Task UpdateLead(int id, LeadDTO request)
        {
            try
            {
                var leadMap = await _context.Lead.FindAsync(id);
                if (leadMap == null)
                {
                    throw new Exception($"Lead com Id {id} não encontrado.");
                }

                if (request.Nome != null)
                    leadMap.Nome = request.Nome;
                if (request.Email != null)
                    leadMap.Email = request.Email;
                if (request.Cpf != null)
                    leadMap.Cpf = request.Cpf;
                if (request.Telefone != null)
                    leadMap.Telefone = request.Telefone;
                await _context.SaveChangesAsync();
            }
            catch (Exception err)
            {
                _logger.LogError(err, $"Ocorreu um erro ao atualizar o Lead de Id {id}.");
                throw;
            }

        }
    }
}