

using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entities;
using Infrastructure.Repositories;
using Application.DTO;
namespace Application.Services
{
    public class InscricaoService : BaseService<Inscricao, InscricaoDTO>
    {
        private readonly InscricaoRepository _repository;
        public InscricaoService(InscricaoRepository repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Inscricao>> GetByCpf(string cpf)
        {
            return await _repository.GetByCpfAsync(cpf);
        }

        public async Task<IEnumerable<Inscricao>> GetByIdOfertaAsync(int id)
        {
            return await _repository.GetByIdOfertaAsync(id);
        }
    }
}