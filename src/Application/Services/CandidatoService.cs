

using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;
using Application.DTO;

namespace Application.Services
{
    public class CandidatoService : BaseService<Candidato, CandidatoDTO>
    {
        public CandidatoService(CandidatoRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}