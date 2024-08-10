using AutoMapper;
using Infraestrutura.Vestibular.Interfaces;
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
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<CandidatoDto>> ObterTodos()
        {
            try
            {
                List<CandidatoDto> candidatoDtos = new List<CandidatoDto>();
                var listCandidato = await _candidato.ObterTodos();
                foreach (var item in listCandidato)
                {
                    candidatoDtos.Add(_mapper.Map<CandidatoDto>(item));
                }
                return candidatoDtos;
            }
            catch(Exception) { throw; }
        }

        public async Task<CandidatoDto> ObterPorId(int id)
        {
            try
            {
                return _mapper.Map<CandidatoDto>(await _candidato.ObertePorId(id));
            }
            catch(Exception) { throw; }
        }

        public async void Apagar(int id)
        {
            try
            {
                Candidato candidato = await _candidato.ObertePorId(id);
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
