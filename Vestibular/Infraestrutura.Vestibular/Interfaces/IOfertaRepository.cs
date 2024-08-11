using Modelo.Vestibular.Entidades;

namespace Infraestrutura.Vestibular.Interfaces
{
    public interface IOfertaRepository
    {
        Task<int> Adicionar(Oferta oferta);

        Task<IEnumerable<Oferta>> ObterTodos();

        Task<Oferta> ObterPorId(int id);

        void Deleta(Oferta oferta);

        void Atualizar(Oferta oferta);
    }
}
