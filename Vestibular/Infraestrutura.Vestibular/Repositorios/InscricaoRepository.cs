using Infraestrutura.Vestibular.Contextos;
using Infraestrutura.Vestibular.Interfaces;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Inscricao>?> ObterPorCpf(string cpf)
        {
            var candidato = await Contexto.Candidatos.Include(i => i.Incricoes)
                                          .FirstOrDefaultAsync(px => px.CPF.Equals(cpf));
            return candidato?.Incricoes;
        }

        public async Task<IEnumerable<Inscricao>?> ObterPorOferta(int id)
        {
            var oferta = await Contexto.Ofertas.Include(i => i.Incricoes)
                                       .FirstOrDefaultAsync(o => o.Id.Equals(id));
            return oferta?.Incricoes;
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
