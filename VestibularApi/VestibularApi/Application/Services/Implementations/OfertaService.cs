using VestibularApi.Domain.Entities;
using VestibularApi.API.Requests;
using VestibularApi.API.Responses;
using VestibularApi.Domain.Repositories.Interfaces;
using VestibularApi.Application.Services.Interfaces;

namespace VestibularApi.Application.Services.Implementations
{
    public class OfertaService : IOfertaService
    {
        private readonly IOfertaRepository _ofertaRepository;

        public OfertaService(IOfertaRepository ofertaRepository)
        {
            _ofertaRepository = ofertaRepository;
        }

        public async Task<IEnumerable<OfertaResponse>> ObterTodasAsync()
        {
            var ofertas = await _ofertaRepository.PegarTodasAsync();
            return ofertas.Select(OfertaResponse.ConverterEntity);
        }

        public async Task<OfertaResponse> ObterPorIdAsync(Guid id)
        {
            var oferta = await _ofertaRepository.PegarPorIdAsync(id);

            if (oferta == null)
            {
                throw new KeyNotFoundException("Oferta não encontrada.");
            }

            return OfertaResponse.ConverterEntity(oferta);
        }

        public async Task<OfertaResponse> CriarAsync(OfertaRequest ofertaRequest)
        {
            if (ofertaRequest == null)
                throw new ArgumentNullException(nameof(ofertaRequest));

            var oferta = new OfertaEntities(ofertaRequest.Nome, ofertaRequest.Descricao, ofertaRequest.DataInicio, ofertaRequest.DataFim, ofertaRequest.VagasDisponiveis);
            await _ofertaRepository.AdicionarAsync(oferta);

            return OfertaResponse.ConverterEntity(oferta);
        }

        public async Task AtualizarAsync(Guid id, OfertaRequest ofertaRequest)
        {
            if (ofertaRequest == null)
                throw new ArgumentNullException(nameof(ofertaRequest));

            var oferta = await _ofertaRepository.PegarPorIdAsync(id);

            if (oferta == null)
            {
                throw new KeyNotFoundException("Oferta não encontrada.");
            }

            oferta.AtualizarOferta(ofertaRequest.Nome, ofertaRequest.Descricao, ofertaRequest.DataInicio, ofertaRequest.DataFim, ofertaRequest.VagasDisponiveis);
            await _ofertaRepository.AtualizarAsync(oferta);
        }

        public async Task DeletarAsync(Guid id)
        {
            var oferta = await _ofertaRepository.PegarPorIdAsync(id);

            if (oferta == null)
            {
                throw new KeyNotFoundException("Oferta não encontrada.");
            }

            await _ofertaRepository.DeletarAsync(id);
        }
    }
}
