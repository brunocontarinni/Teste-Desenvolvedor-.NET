using VestibularApi.Domain.Entities;
using VestibularApi.Domain.Repositories;

namespace VestibularApi.Application.Services
{
    public class CandidatoService
    {
        private readonly ICandidatoRepository _candidatoRepository;

        public CandidatoService(ICandidatoRepository candidatoRepository)
        {
            _candidatoRepository = candidatoRepository;
        }

        public async Task<Candidato> PegarPorIdAsync(Guid id)
        {
            return await _candidatoRepository.PegarPorIdAsync(id);
        }

        public async Task<IEnumerable<Candidato>> PegarTodosAsync()
        {
            return await _candidatoRepository.PegarTodosAsync();
        }

        public async Task AdicionarAsync(Candidato candidato)
        {
            await _candidatoRepository.AdicionarAsync(candidato);
        }

        public async Task AtualizarAsync(Candidato candidato)
        {
            await _candidatoRepository.AtualizarAsync(candidato);
        }

        public async Task DeletarAsync(Guid id)
        {
            await _candidatoRepository.DeletarAsync(id);
        }
    }
}
