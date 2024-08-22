using VestibularApi.Domain.Entities;
using VestibularApi.API.Requests;
using VestibularApi.API.Responses;
using VestibularApi.Domain.Repositories.Interfaces;
using VestibularApi.Application.Services.Interfaces;

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
            return inscricoes.Select(i => new InscricaoResponse(
                i.Id,
                i.NumeroInscricao,
                i.Data,
                i.Status,
                i.ProcessoSeletivoId,
                i.ProcessoSeletivo?.Nome ?? string.Empty,
                i.OfertaId,
                i.Oferta?.Nome ?? string.Empty,
                i.CandidatoId,
                i.Candidato?.Nome ?? string.Empty));
        }

        public async Task<InscricaoResponse> ObterPorIdAsync(Guid id)
        {
            var inscricao = await _inscricaoRepository.PegarPorIdAsync(id);

            if (inscricao == null)
            {
                throw new KeyNotFoundException("Inscrição não encontrada.");
            }

            return new InscricaoResponse(
                inscricao.Id,
                inscricao.NumeroInscricao,
                inscricao.Data,
                inscricao.Status,
                inscricao.ProcessoSeletivoId,
                inscricao.ProcessoSeletivo?.Nome ?? string.Empty,
                inscricao.OfertaId,
                inscricao.Oferta?.Nome ?? string.Empty,
                inscricao.CandidatoId,
                inscricao.Candidato?.Nome ?? string.Empty);
        }

        public async Task<InscricaoResponse> CriarAsync(InscricaoRequest inscricaoRequest)
        {
            if (inscricaoRequest == null)
                throw new ArgumentNullException(nameof(inscricaoRequest));

            var inscricao = new InscricaoEntities(
                inscricaoRequest.NumeroInscricao,
                inscricaoRequest.ProcessoSeletivoId,
                inscricaoRequest.OfertaId,
                inscricaoRequest.CandidatoId,
                inscricaoRequest.DataInscricao,
                inscricaoRequest.Status);

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

        public async Task<IEnumerable<InscricaoResponse>> PegarPorCpfAsync(string cpf)
        {
            var inscricoes = await _inscricaoRepository.PegarPorCpfAsync(cpf);
            return inscricoes.Select(i => InscricaoResponse.ConverterEntity(i));
        }

        public async Task<IEnumerable<InscricaoResponse>> PegarPorOfertaAsync(Guid ofertaId)
        {
            var inscricoes = await _inscricaoRepository.PegarPorOfertaAsync(ofertaId);
            return inscricoes.Select(i => InscricaoResponse.ConverterEntity(i));
        }
    }
}
