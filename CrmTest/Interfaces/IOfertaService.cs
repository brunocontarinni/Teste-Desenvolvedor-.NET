using CrmTest.DTO;
using CrmTest.Models;

namespace CrmTest.Interface{
    public interface IOfertaServices{
        Task<IEnumerable<Oferta>> GetAllOfertas();
        Task<Oferta> GetOfertaById(int id);
        Task CreateOferta(Oferta Oferta);
        Task UpdateOferta(int id, OfertaDTO Oferta);
        Task DeleteOferta(int id);
    }
}