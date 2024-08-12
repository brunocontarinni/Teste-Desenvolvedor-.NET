using AutoMapper;
using CrmTest.AppDataContext;
using CrmTest.DTO;
using CrmTest.Interface;
using CrmTest.Models;
using Microsoft.EntityFrameworkCore;

namespace CrmTest.Services
{
   public class ProcessoSeletivoServices : IProcessoSeletivoServices
   {
      private readonly CrmTestDbContex _context;
      private readonly ILogger<ProcessoSeletivoServices> _logger;
      private readonly IMapper _mapper;

      public ProcessoSeletivoServices(CrmTestDbContex context, ILogger<ProcessoSeletivoServices> logger, IMapper mapper)
      {
         _context = context;
         _logger = logger;
         _mapper = mapper;
      }

      public async Task<IEnumerable<ProcessoSeletivo>> GetAllProcessoSeletivos()
      {
         var processoSeletivoMapping= await _context.ProcessoSeletivo.ToListAsync();
         if (processoSeletivoMapping == null)
         {
            throw new Exception("Sem Processo Seletivos encontradas");
         }
         return processoSeletivoMapping;
      }

      public async Task<ProcessoSeletivo> GetProcessoSeletivoById(int id)
      {
         var processoSeletivoMap = await _context.ProcessoSeletivo.FindAsync(id);
         if (processoSeletivoMap == null)
            throw new Exception("Processo Seletivo Não encontrada.");
         return processoSeletivoMap;
      }

      public async Task CreateProcessoSeletivo(ProcessoSeletivo request)
      {
         try
         {
            var processoSeletivoMap = _mapper.Map<ProcessoSeletivo>(request);
            _context.ProcessoSeletivo.Add(processoSeletivoMap);
            await _context.SaveChangesAsync();
         }
         catch (Exception e)
         {
            _logger.LogError(e, "Ocorreu um erro ao criar o processo seletivo.");
            throw new Exception("Ocorreu um erro ao criar o processo seletivo.");
         }
      }

      public async Task UpdateProcessoSeletivo(int id, ProcessoSeletivoDTO request)
      {
         try
         {
            var processoSeletivoMap = await _context.ProcessoSeletivo.FindAsync(id);
            if (processoSeletivoMap == null)
               throw new Exception($"Processo seletivo com Id {id} não encontrado");

            if (request.Nome != null)
               processoSeletivoMap.Nome = request.Nome;
            if (request.Dt_inicio != null)
               processoSeletivoMap.Dt_inicio = request.Dt_inicio;
            if (request.Dt_fim != null)
               processoSeletivoMap.Dt_fim = processoSeletivoMap.Dt_fim;
            await _context.SaveChangesAsync();
         }
         catch (Exception err)
         {
            _logger.LogError(err, $"Ocorreu um erro ao atualizar a Oferta de Id {id}.");
            throw;
         }
      }

      public async Task DeleteProcessoSeletivo(int id)
      {
         try
         {
            var processoSeletivoMap = await _context.ProcessoSeletivo.FindAsync(id);
            if (processoSeletivoMap != null)
            {
               _context.ProcessoSeletivo.Remove(processoSeletivoMap);
               await _context.SaveChangesAsync();
            }
            else
            {
               throw new Exception($"Processo Seletivo com Id {id} não encontrada.");
            }
         }
         catch (Exception err)
         {
            _logger.LogError(err, "Ocorreu um erro ao excluir Processo Seletivo.");
            throw new Exception("Ocorreu um erro ao excluir Processo Seletivo.");
         }
      }
   }
}

