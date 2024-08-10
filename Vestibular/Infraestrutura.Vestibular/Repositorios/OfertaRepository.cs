using Infraestrutura.Vestibular.Contextos;
using Infraestrutura.Vestibular.Interfaces;
using Modelo.Vestibular.Entidades;

namespace Infraestrutura.Vestibular.Repositorios
{
    public class OfertaRepository : Repository<Oferta>, IOfertaRepository
    {
        public OfertaRepository(VestibularDB contexto) : base(contexto) { }

        public async Task<int> Adicionar(Oferta oferta)
        {
            await AddAsync(oferta);
            return oferta.Id;
        }

        public void Atualizar(Oferta oferta)
        {
            Update(oferta);
        }

        public void Deleta(Oferta oferta)
        {
            Remove(oferta);
        }

        public async Task<Oferta> ObertePorId(int id)
        {
            return await GetByIdAsync(id);
        }

        public async Task<IEnumerable<Oferta>> ObterTodos()
        {
            return await GetAllAsync();
        }
    }
}
