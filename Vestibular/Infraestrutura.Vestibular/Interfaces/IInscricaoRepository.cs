using Modelo.Vestibular.Entidades;

namespace Infraestrutura.Vestibular.Interfaces
{
    public interface IInscricaoRepository
    {
        Task<int> Adicionar(Inscricao inscricao);

        Task<IEnumerable<Inscricao>> ObterTodos();

        Task<Inscricao> ObertePorId(int id);

        void Deleta(Inscricao inscricao);

        void Atualizar(Inscricao inscricao);

        Task<IEnumerable<Inscricao>?> ObterPorCpf(string cpf);

        Task<IEnumerable<Inscricao>?> ObterPorOferta(int id);
    }
}
