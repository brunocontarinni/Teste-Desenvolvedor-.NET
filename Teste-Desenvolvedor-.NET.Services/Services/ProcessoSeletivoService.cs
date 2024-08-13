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
            // Mapeia o modelo para a Entidade de Dominio
            var processo = _mapper.Map<ProcessoSeletivo>(model);

            // Verifica se ha alguma notificação
            if (processo.Notificacao.Any())
            {
                return processo;
            }

            // Salva nova Oferta no banco
            await _dbContext.ProcessosSeletivos.AddAsync(processo);
            await _dbContext.SaveChangesAsync();
            return processo;
        }

        public async Task<ProcessoSeletivo> AtualizarProcessoSeletivo(Guid id, ProcessoSeletivoModel model)
        {
            // Mapeia o modelo para a Entidade de Dominio
            var processo = _mapper.Map<ProcessoSeletivo>(model);
            
            // Procura a entidade no banco
            var existe = await _dbContext.ProcessosSeletivos.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(y => y.Id == id);

            // Caso não encontrar retone nulo
            if (existe == null)
            {
                return null;
            }

            // Atualiza as propriedade
            existe.Atualizar(processo.Nome, processo.DataInicio, processo.DataTermino);

            // Retorna se existir alguma notificação
            if (existe.Notificacao.Any())
            {
                return existe;
            }

            // Salva as alterações no banco
            _dbContext.ProcessosSeletivos.Update(existe);
            await _dbContext.SaveChangesAsync();

            return existe;
        }

        public async Task<bool> DeletarProcessoSeletivo(Guid id)
        {
            // Procura pelo Processo Seletivo no banco de dados
            var processo = await _dbContext.ProcessosSeletivos.Where(x => x.Deleted == false)
                .FirstOrDefaultAsync(y => y.Id == id);

            // Caso nao encotrar retorna falso
            if (processo == null)
            {
                return false;
            }

            //Atualiza a fleg de deleção para true
            processo.Delete();

            //Salva as alterações no baco de dados
            _dbContext.ProcessosSeletivos.Update(processo);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<ProcessoSeletivo>> GetAllProcessoSeletivo()
        {
            // Retorna todos os Processo Seletivos não deletados
            return await _dbContext.ProcessosSeletivos.Where(x => x.Deleted == false).ToListAsync();
        }

        public async Task<ProcessoSeletivo> GetProcessoSeletivo(Guid id)
        {
            // Retorna um Processo Seletivo não deletado
            return await _dbContext.ProcessosSeletivos.Where(x => x.Deleted == false)
               .FirstOrDefaultAsync(y => y.Id == id);
        }
    }
}
