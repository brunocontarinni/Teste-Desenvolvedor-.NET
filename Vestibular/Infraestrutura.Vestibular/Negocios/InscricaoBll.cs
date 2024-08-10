using AutoMapper;
using Infraestrutura.Vestibular.Interfaces;
using Modelo.Vestibular.Dtos;
using Modelo.Vestibular.Entidades;
using Modelo.Vestibular.ModelView;

namespace Infraestrutura.Vestibular.Negocios
{
    public class InscricaoBll
    {
        private readonly IInscricaoRepository _repository;
        private readonly IMapper _mapper;

        public InscricaoBll(IInscricaoRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> Criar(InscricaoModelView modelView)
        {
            try
            {
                Inscricao inscricao = _mapper.Map<Inscricao>(modelView);
                return await _repository.Adicionar(inscricao);
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<InscricaoDto>> ObterTodos()
        {
            try
            {
                List<InscricaoDto> inscricaoDtoSeletivoDtos = new List<InscricaoDto>();
                var listProcesso = await _repository.ObterTodos();
                foreach (var item in listProcesso)
                {
                    inscricaoDtoSeletivoDtos.Add(_mapper.Map<InscricaoDto>(item));
                }
                return inscricaoDtoSeletivoDtos;
            }
            catch (Exception) { throw; }
        }

        public async Task<InscricaoDto> ObterPorId(int id)
        {
            try
            {
                return _mapper.Map<InscricaoDto>(await _repository.ObertePorId(id));
            }
            catch (Exception) { throw; }
        }

        public async void Apagar(int id)
        {
            try
            {
                Inscricao inscricao = await _repository.ObertePorId(id);
                if (inscricao is Inscricao)
                    _repository.Deleta(inscricao);
                else
                    throw new NullReferenceException("Oferta não encontrado.");
            }
            catch (Exception) { throw; }
        }

        public void Atualizar(int id, InscricaoModelView modelView)
        {
            try
            {
                Inscricao inscricao = _mapper.Map<Inscricao>(modelView);
                inscricao.Id = id;
                _repository.Atualizar(inscricao);
            }
            catch (Exception) { throw; }
        }
    }
}
