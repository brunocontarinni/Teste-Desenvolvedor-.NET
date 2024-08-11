using AutoMapper;
using Infraestrutura.Vestibular.Interfaces;
using Modelo.Vestibular.Dtos;
using Modelo.Vestibular.Entidades;
using Modelo.Vestibular.ModelView;

namespace Infraestrutura.Vestibular.Negocios
{
    public class OfertaBll
    {
        private readonly IOfertaRepository _oferta;
        private readonly IMapper _mapper;

        public OfertaBll(IOfertaRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _oferta = repository;
        }

        public async Task<int> Criar(OfertaModelView modelView)
        {
            try
            {
                Oferta oferta = _mapper.Map<Oferta>(modelView);
                return await _oferta.Adicionar(oferta);
            }
            catch (Exception) { throw; }
        }

        public async Task<IEnumerable<OfertaDto>> ObterTodos()
        {
            try
            {
                var listOferta = await _oferta.ObterTodos();
                return _mapper.Map<IEnumerable<OfertaDto>>(listOferta);
            }
            catch (Exception) { throw; }
        }

        public async Task<OfertaDto> ObterPorId(int id)
        {
            try
            {
                var oferta = await _oferta.ObterPorId(id);
                if(oferta is Oferta)
                    return _mapper.Map<OfertaDto>(oferta);
                
                throw new NullReferenceException($"Não foi encontrado o {nameof(Oferta)}");
            }
            catch (Exception) { throw; }
        }

        public async Task Apagar(int id)
        {
            try
            {
                Oferta oferta = await _oferta.ObterPorId(id);
                if (oferta is Oferta)
                    _oferta.Deleta(oferta);
                else
                    throw new NullReferenceException("Oferta não encontrado.");
            }
            catch (Exception) { throw; }
        }

        public void Atualizar(int id, OfertaModelView modelView)
        {
            try
            {
                Oferta oferta = _mapper.Map<Oferta>(modelView);
                oferta.Id = id;
                _oferta.Atualizar(oferta);
            }
            catch (Exception) { throw; }
        }
    }
}
