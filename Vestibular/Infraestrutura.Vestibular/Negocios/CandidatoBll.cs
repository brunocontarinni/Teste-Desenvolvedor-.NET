using AutoMapper;
using Infraestrutura.Vestibular.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Modelo.Vestibular.Dtos;
using Modelo.Vestibular.Entidades;
using Modelo.Vestibular.ModelView;

namespace Infraestrutura.Vestibular.Negocios
{
    public class CandidatoBll
    {
        private readonly ICandidatoRepository _candidato;
        private readonly IMapper _mapper;
        
        public CandidatoBll(ICandidatoRepository repository, IMapper mapper)
        {
            _candidato = repository;
            _mapper = mapper;
        }

        public async Task<int> Criar(CandidatoModelView modelView)
        {
            try
            {
                Candidato candidato = _mapper.Map<Candidato>(modelView);
                return await _candidato.Adicionar(candidato);
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is not null && ex.InnerException.Message.Contains("IX_Candidatos_CPF")) 
                {
                    throw new DbUpdateException($"O CPF {modelView.CPF} já encotra-se cadastrado.");
                }
                throw; 
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<CandidatoDto>> ObterTodos()
        {
            try
            {
                var listCandidato = await _candidato.ObterTodos();
                return _mapper.Map<IEnumerable<CandidatoDto>>(listCandidato);
            }
            catch(Exception) { throw; }
        }

        public async Task<CandidatoDto> ObterPorId(int id)
        {
            try
            {
                var candidato = await _candidato.ObterPorId(id);
                if(candidato is Candidato)
                    return _mapper.Map<CandidatoDto>(candidato);

                throw new NullReferenceException($"Não foi encontrado o {nameof(Candidato)}");
            }
            catch(Exception) { throw; }
        }

        public async Task Apagar(int id)
        {
            try
            {
                Candidato candidato = await _candidato.ObterPorId(id);
                if (candidato is Candidato) 
                    _candidato.Deleta(candidato);
                else
                    throw new NullReferenceException("Candidato não encontrado.");
            }
            catch (Exception) 
            {
                throw;
            }
        }

        public void Atualizar(int id, CandidatoModelView modelView)
        {
            try
            {
                Candidato candidato = _mapper.Map<Candidato>(modelView);
                candidato.Id = id;
                _candidato.Atualizar(candidato);
            }
            catch (Exception) { throw; }
        }
    }
}
