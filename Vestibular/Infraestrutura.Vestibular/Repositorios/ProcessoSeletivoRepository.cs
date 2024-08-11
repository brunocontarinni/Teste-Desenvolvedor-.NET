using Infraestrutura.Vestibular.Contextos;
using Infraestrutura.Vestibular.Interfaces;
using Modelo.Vestibular.Entidades;

namespace Infraestrutura.Vestibular.Repositorios
{
    public class ProcessoSeletivoRepository : Repository<ProcessoSeletivo>, IProcessoSeletivoRepository
    {
        public ProcessoSeletivoRepository(VestibularDB contexto) : base(contexto) { }

        public async Task<int> Adicionar(ProcessoSeletivo processoSeletivo)
        {
            await AddAsync(processoSeletivo);
            return processoSeletivo.Id;
        }

        public void Atualizar(ProcessoSeletivo processoSeletivo)
        {
            Update(processoSeletivo);
        }

        public void Deleta(ProcessoSeletivo processoSeletivo)
        {
            Remove(processoSeletivo);
        }

        public async Task<ProcessoSeletivo> ObterPorId(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<IEnumerable<ProcessoSeletivo>> ObterTodos()
        {
            return await GetAllAsync();
        }
    }
}
