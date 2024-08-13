using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Teste_Desenvolvedor_.NET.Data.Repositories;
using Teste_Desenvolvedor_.NET.Domain.Entities;
using Teste_Desenvolvedor_.NET.Models.Models;
using Teste_Desenvolvedor_.NET.Services.Interfaces;

namespace Teste_Desenvolvedor_.NET.Services.Services
{
    public class ProcessoSeletivoService : IProcessoSeletivoService
    {
        private readonly IMapper _mapper;
        private readonly DBContext _dbContext;

        public ProcessoSeletivoService(IMapper mapper, DBContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public async Task<ProcessoSeletivo> AdicionarProcessoSeletivo(ProcessoSeletivoModel model)
        {
            var processo = _mapper.Map<ProcessoSeletivo>(model);

            if (processo.Notificacao.Any())
            {
                return processo;
            }

            await _dbContext.ProcessosSeletivos.AddAsync(processo);
            await _dbContext.SaveChangesAsync();
            return processo;
        }

        public async Task<ProcessoSeletivo> AtualizarProcessoSeletivo(Guid id, ProcessoSeletivoModel model)
        {
            var processo = _mapper.Map<ProcessoSeletivo>(model);
            var existe = await _dbContext.ProcessosSeletivos.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(y => y.Id == id);
            if (existe == null)
            {
                return null;
            }

            existe.Atualizar(processo.Nome, processo.DataInicio, processo.DataTermino);

            if (existe.Notificacao.Any())
            {
                return existe;
            }

            _dbContext.ProcessosSeletivos.Update(existe);
            await _dbContext.SaveChangesAsync();

            return existe;
        }

        public async Task<bool> DeletarProcessoSeletivo(Guid id)
        {
            var processo = await _dbContext.ProcessosSeletivos.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(y => y.Id == id);
            if (processo == null)
            {
                return false;
            }

            processo.Delete();
            _dbContext.ProcessosSeletivos.Update(processo);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ProcessoSeletivo>> GetAllProcessoSeletivo()
        {
            return await _dbContext.ProcessosSeletivos.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<ProcessoSeletivo> GetProcessoSeletivo(Guid id)
        {
            return await _dbContext.ProcessosSeletivos.Where(x => x.Deleted == false)
               .FirstOrDefaultAsync(y => y.Id == id);
        }
    }
}
