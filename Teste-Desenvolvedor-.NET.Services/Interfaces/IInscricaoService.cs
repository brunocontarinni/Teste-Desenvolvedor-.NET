using Teste_Desenvolvedor_.NET.Domain.Entities;
using Teste_Desenvolvedor_.NET.Models.Models;

namespace Teste_Desenvolvedor_.NET.Services.Interfaces
{
    public interface IInscricaoService
    {
        Task<Inscricao> AdicionarInscricao(InscricaoModel model);
        Task<Inscricao> GetInscricao(Guid id);
        Task<IEnumerable<Inscricao>> GetAllInscricao();
        Task<bool> DeletarInscricao(Guid id);
        Task<Inscricao> AtualizarInscricao(Guid id, InscricaoModel inscricao);
        Task<IEnumerable<Inscricao>> GetInscicoesCPF(string cpf);
        Task<IEnumerable<Inscricao>> GetInscicoesOferta(Guid id);

    }
}
