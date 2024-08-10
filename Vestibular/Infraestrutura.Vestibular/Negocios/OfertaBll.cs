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
                List<OfertaDto> ofertaDtos = new List<OfertaDto>();
                var listOferta = await _oferta.ObterTodos();
                foreach (var item in listOferta)
                {
                    ofertaDtos.Add(_mapper.Map<OfertaDto>(item));
                }
                return ofertaDtos;
            }
            catch (Exception) { throw; }
        }

        public async Task<OfertaDto> ObterPorId(int id)
        {
            try
            {
                return _mapper.Map<OfertaDto>(await _oferta.ObertePorId(id));
            }
            catch (Exception) { throw; }
        }

        public async void Apagar(int id)
        {
            try
            {
                Oferta oferta = await _oferta.ObertePorId(id);
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
