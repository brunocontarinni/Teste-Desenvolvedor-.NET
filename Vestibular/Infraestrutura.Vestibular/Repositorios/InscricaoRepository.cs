using Infraestrutura.Vestibular.Contextos;
using Infraestrutura.Vestibular.Interfaces;
using Modelo.Vestibular.Entidades;

namespace Infraestrutura.Vestibular.Repositorios
{
    public class InscricaoRepository : Repository<Inscricao>, IInscricaoRepository
    {
        public InscricaoRepository(VestibularDB contexto) : base(contexto) { }

        public async Task<int> Adicionar(Inscricao inscricao)
        {
            await AddAsync(inscricao);
            return inscricao.Id;
        }

        public void Atualizar(Inscricao inscricao)
        {
            Update(inscricao);
        }

        public void Deleta(Inscricao inscricao)
        {
            Remove(inscricao);
        }

        async Task<Inscricao> IInscricaoRepository.ObertePorId(int id)
        {
            return await GetByIdAsync(id);
        }

        async Task<IEnumerable<Inscricao>> IInscricaoRepository.ObterTodos()
        {
            return await GetAllAsync();
        }
    }
}
