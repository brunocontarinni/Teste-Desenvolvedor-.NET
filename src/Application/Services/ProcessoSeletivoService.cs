

using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;
using Application.DTO;

namespace Application.Services
{
    public class ProcessoSeletivoService : BaseService<ProcessoSeletivo, ProcessoSeletivoDTO>
    {
        public ProcessoSeletivoService(ProcessoSeletivoRepository repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}