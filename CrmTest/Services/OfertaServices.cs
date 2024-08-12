using AutoMapper;
using CrmTest.AppDataContext;
using CrmTest.DTO;
using CrmTest.Interface;
using CrmTest.Models;
using Microsoft.EntityFrameworkCore;

namespace CrmTest.Services
{
    public class OfertaServices : IOfertaServices
    {
        private readonly CrmTestDbContex _context;
        private readonly ILogger<OfertaServices> _logger;
        private readonly IMapper _mapper;

        public OfertaServices(CrmTestDbContex context, ILogger<OfertaServices> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Oferta>> GetAllOfertas()
        {
            var ofertaMapping= await _context.Oferta.ToListAsync();
            if (ofertaMapping == null)
            {
                throw new Exception("Sem ofertas encontradas");
            }
            return ofertaMapping;
        }

        public async Task<Oferta> GetOfertaById(int id)
        {
                var ofertaMap = await _context.Oferta.FindAsync(id);
                if (ofertaMap == null)
                    throw new Exception("Oferta Não encontrada.");
                return ofertaMap;
        }

        public async Task CreateOferta(Oferta request)
        {
            try
            {
                var ofertaMap = _mapper.Map<Oferta>(request);
                _context.Oferta.Add(ofertaMap);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Ocorreu um erro ao criar a Oferta.");
                throw new Exception("Ocorreu um erro ao criar a oferta.");
            }
        }

        public async Task UpdateOferta(int id, OfertaDTO request)
        {
            try
            {
                var ofertaMap = await _context.Oferta.FindAsync(id);
                if (ofertaMap == null)
                    throw new Exception($"Oferta com Id {id} não encontrada.");

                if (request.Nome != null)
                    ofertaMap.Nome = request.Nome;
                if (request.Descricao != null)
                    ofertaMap.Descricao = request.Descricao;
                if (request.Qtd_Vagas_Disponiveis != null)
                    ofertaMap.Qtd_Vagas_Disponiveis = request.Qtd_Vagas_Disponiveis;
                await _context.SaveChangesAsync();
            }
            catch (Exception err)
            {
                _logger.LogError(err, $"Ocorreu um erro ao atualizar a Oferta de Id {id}.");
                throw;
            }
        }

        public async Task DeleteOferta(int id)
        {
            try
            {
                var ofertaMap = await _context.Oferta.FindAsync(id);
                if (ofertaMap != null)
                {
                    _context.Oferta.Remove(ofertaMap);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Oferta com Id {id} não encontrada.");
                }
            }
            catch (Exception err)
            {
                _logger.LogError(err, "Ocorreu um erro ao excluir Oferta.");
                throw new Exception("Ocorreu um erro ao excluir Oferta");
            }
        }
    }
}

