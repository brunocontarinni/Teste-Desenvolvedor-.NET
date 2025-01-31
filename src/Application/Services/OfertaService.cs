

using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;
using Application.DTO;

namespace Application.Services
{
    public class OfertaService : BaseService<Oferta, OfertaDTO>
    {
        public OfertaService(OfertaRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}