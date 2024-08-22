using VestibularApi.API.Requests;
using VestibularApi.API.Responses;
using VestibularApi.Application.Services.Interfaces;
using VestibularApi.Domain.Entities;
using VestibularApi.Domain.Repositories.Interfaces;

namespace VestibularApi.Application.Services.Implementations
{
    public class CandidatoService : ICandidatoService
    {
        private readonly ICandidatoRepository _candidatoRepository;

        public CandidatoService(ICandidatoRepository candidatoRepository)
        {
            _candidatoRepository = candidatoRepository;
        }

        public async Task<IEnumerable<CandidatoResponse>> ObterTodosAsync()
        {
            var candidatos = await _candidatoRepository.PegarTodosAsync();
            return candidatos.Select(c => new CandidatoResponse(c.Id, c.Nome, c.CPF, c.DataCriacao));
        }


        public async Task<CandidatoResponse> ObterPorIdAsync(Guid id)
        {
            var candidato = await _candidatoRepository.PegarPorIdAsync(id);

            if (candidato == null)
            {
                throw new KeyNotFoundException("Candidato não encontrado.");
            }

            return new CandidatoResponse(candidato.Id, candidato.Nome, candidato.CPF, candidato.DataCriacao);
        }

        public async Task<CandidatoResponse> CriarAsync(CandidatoRequest candidatoRequest)
        {
            if (candidatoRequest == null)
                throw new ArgumentNullException(nameof(candidatoRequest));

            var candidato = new CandidatoEntities(candidatoRequest.Nome, candidatoRequest.CPF);
            await _candidatoRepository.AdicionarAsync(candidato);

            return CandidatoResponse.ConverterEntity(candidato);


        }

        public async Task AtualizarAsync(Guid id, CandidatoRequest candidatoRequest)
        {
            if (candidatoRequest == null)
                throw new ArgumentNullException(nameof(candidatoRequest));

            var candidato = await _candidatoRepository.PegarPorIdAsync(id);

            if (candidato == null)
            {
                throw new KeyNotFoundException("Candidato não encontrado.");
            }

            candidato.AlterarNome(candidatoRequest.Nome);
            candidato.AlterarCPF(candidatoRequest.CPF);

            await _candidatoRepository.AtualizarAsync(candidato);
        }

        public async Task DeletarAsync(Guid id)
        {
            var candidato = await _candidatoRepository.PegarPorIdAsync(id);

            if (candidato == null)
            {
                throw new KeyNotFoundException("Candidato não encontrado.");
            }

            await _candidatoRepository.DeletarAsync(id);
        }
    }
}
