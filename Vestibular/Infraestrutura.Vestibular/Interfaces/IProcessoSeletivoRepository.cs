using Modelo.Vestibular.Entidades;

namespace Infraestrutura.Vestibular.Interfaces
{
    public interface IProcessoSeletivoRepository
    {
        Task<int> Adicionar(ProcessoSeletivo processoSeletivo);

        Task<IEnumerable<ProcessoSeletivo>> ObterTodos();

        Task<ProcessoSeletivo> ObterPorId(int id);

        void Deleta(ProcessoSeletivo processoSeletivo);

        void Atualizar(ProcessoSeletivo processoSeletivo);
    }
}
