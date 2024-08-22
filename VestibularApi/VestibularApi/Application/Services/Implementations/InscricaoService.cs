using VestibularApi.Domain.Entities;
using VestibularApi.API.Requests;
using VestibularApi.API.Responses;
using VestibularApi.Domain.Repositories.Interfaces;
using VestibularApi.Application.Services.Inscricao;

namespace VestibularApi.Application.Services.Implementations
{
    public class InscricaoService : IInscricaoService
    {
        private readonly IInscricaoRepository _inscricaoRepository;

        public InscricaoService(IInscricaoRepository inscricaoRepository)
        {
            _inscricaoRepository = inscricaoRepository;
        }

        public async Task<IEnumerable<InscricaoResponse>> ObterTodasAsync()
        {
            var inscricoes = await _inscricaoRepository.PegarTodasAsync();
            return inscricoes.Select(i => new InscricaoResponse(i.Id, i.CandidatoId, i.Candidato.Nome, i.OfertaId, i.Oferta.Nome, i.DataInscricao, i.Status));
        }

        public async Task<InscricaoResponse> ObterPorIdAsync(Guid id)
        {
            var inscricao = await _inscricaoRepository.PegarPorIdAsync(id);

            if (inscricao == null)
            {
                throw new KeyNotFoundException("Inscrição não encontrada.");
            }

            return new InscricaoResponse(inscricao.Id, inscricao.CandidatoId, inscricao.Candidato.Nome, inscricao.OfertaId, inscricao.Oferta.Nome, inscricao.DataInscricao, inscricao.Status);
        }

        public async Task<InscricaoResponse> CriarAsync(InscricaoRequest inscricaoRequest)
        {
            if (inscricaoRequest == null)
                throw new ArgumentNullException(nameof(inscricaoRequest));

            var inscricao = new InscricaoEntities(inscricaoRequest.CandidatoId, inscricaoRequest.OfertaId, inscricaoRequest.DataInscricao, inscricaoRequest.Status);
            await _inscricaoRepository.AdicionarAsync(inscricao);

            return InscricaoResponse.ConverterEntity(inscricao);
        }

        public async Task<InscricaoResponse> AtualizarAsync(Guid id, InscricaoRequest inscricaoRequest)
        {
            if (inscricaoRequest == null)
                throw new ArgumentNullException(nameof(inscricaoRequest));

            var inscricao = await _inscricaoRepository.PegarPorIdAsync(id);

            if (inscricao == null)
            {
                throw new KeyNotFoundException("Inscrição não encontrada.");
            }

            inscricao.AtualizarStatus(inscricaoRequest.Status);
            await _inscricaoRepository.AtualizarAsync(inscricao);

            return InscricaoResponse.ConverterEntity(inscricao);
        }

        public async Task DeletarAsync(Guid id)
        {
            var inscricao = await _inscricaoRepository.PegarPorIdAsync(id);

            if (inscricao == null)
            {
                throw new KeyNotFoundException("Inscrição não encontrada.");
            }

            await _inscricaoRepository.DeletarAsync(id);
        }
    }
}
