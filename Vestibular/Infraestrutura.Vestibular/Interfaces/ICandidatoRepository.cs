using Modelo.Vestibular.Entidades;

namespace Infraestrutura.Vestibular.Interfaces
{
    public interface ICandidatoRepository
    {
        Task<int> Adicionar(Candidato candidato);

        Task<IEnumerable<Candidato>> ObterTodos();

        Task<Candidato> ObertePorId(int id);

        void Deleta(Candidato candidato);

        void Atualizar(Candidato candidato);
    }
}
