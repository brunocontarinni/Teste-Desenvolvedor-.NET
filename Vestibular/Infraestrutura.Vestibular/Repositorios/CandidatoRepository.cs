using Infraestrutura.Vestibular.Contextos;
using Infraestrutura.Vestibular.Interfaces;
using Modelo.Vestibular.Entidades;

namespace Infraestrutura.Vestibular.Repositorios
{
    public class CandidatoRepository : Repository<Candidato>, ICandidatoRepository
    {
        public CandidatoRepository(VestibularDB contexto) : base(contexto) { }

        public async Task<int> Adicionar(Candidato candidato)
        {
            await AddAsync(candidato);
            return candidato.Id;
        }

        public void Atualizar(Candidato candidato)
        {
            Update(candidato);
        }

        public void Deleta(Candidato candidato)
        {
            Remove(candidato);
        }

        public async Task<Candidato> ObertePorId(int id)
        {
           return await GetByIdAsync(id);
        }

        public async Task<IEnumerable<Candidato>> ObterTodos()
        {
            return await GetAllAsync();
        }
    }
}
