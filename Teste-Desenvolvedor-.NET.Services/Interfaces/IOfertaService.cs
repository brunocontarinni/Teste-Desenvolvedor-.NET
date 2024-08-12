using Teste_Desenvolvedor_.NET.Domain.Entities;
using Teste_Desenvolvedor_.NET.Models.Models;

namespace Teste_Desenvolvedor_.NET.Services.Interfaces
{
    public interface IOfertaService
    {
        Task<Oferta> AdicionarOferta(OfertaModel model);
        Task<Oferta> GetOferta(Guid id);
        Task<IEnumerable<Oferta>> GetAllOferta();
        Task<bool> DeletarOferta(Guid id);
        Task<Oferta> AtualizarOferta(Guid id, OfertaModel model);

    }
}
