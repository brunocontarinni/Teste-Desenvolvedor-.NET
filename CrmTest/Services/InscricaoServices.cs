using AutoMapper;
using CrmTest.AppDataContext;
using CrmTest.DTO;
using CrmTest.Interface;
using CrmTest.Models;
using Microsoft.EntityFrameworkCore;

namespace CrmTest.Services
{
    public class InscricaoServices : IInscricaoServices
    {
        private readonly CrmTestDbContex _context;
        private readonly ILogger<InscricaoServices> _logger;
        private readonly IMapper _mapper;

        public InscricaoServices(CrmTestDbContex context, ILogger<InscricaoServices> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Inscricao>> GetAllInscricoes()
        {
            var inscricaoMapping= await _context.Inscricao.ToListAsync();
            if (inscricaoMapping == null)
            {
                throw new Exception("Sem leads encontrados");
            }
            return inscricaoMapping;
        }

        public async Task<Inscricao> GetInscricaoById(int id)
        {
            var inscricaoMap = await _context.Inscricao.FindAsync(id);
            if (inscricaoMap == null)
                throw new Exception("Oferta Não encontrada.");
            return inscricaoMap;
        }

        public async Task CreateInscricao(Inscricao request)
        {
            try{
                var inscricaoMapping = _mapper.Map<Inscricao>(request);
                inscricaoMapping.Dt_inscricao = DateTime.UtcNow;
                _context.Inscricao.Add(inscricaoMapping);
                await _context.SaveChangesAsync();
            }catch(Exception e){
                _logger.LogError(e, "Ocorreu um erro ao criar Lead.");
                throw new Exception("Ocorreu um erro ao criar Lead");
            }
        }

        public async Task UpdateInscricao(int id, InscricaoDTO request)
        {
            try
            {
                var inscricaoMap = await _context.Inscricao.FindAsync(id);
                if (inscricaoMap == null)
                {
                    throw new Exception($"Lead com Id {id} não encontrado.");
                }

                if (request.Status != null)
                    inscricaoMap.Status = request.Status;

                await _context.SaveChangesAsync();
            }
            catch (Exception err)
            {
                _logger.LogError(err, $"Ocorreu um erro ao atualizar o Lead de Id {id}.");
                throw;
            }

        }

        public async Task DeleteInscricao(int id)
        {
            var inscricaoMap = await _context.Inscricao.FindAsync(id);
            if (inscricaoMap != null)
            {
                _context.Inscricao.Remove(inscricaoMap);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Lead de Id {id} não encontrado.");
            }
        }
    }
}

