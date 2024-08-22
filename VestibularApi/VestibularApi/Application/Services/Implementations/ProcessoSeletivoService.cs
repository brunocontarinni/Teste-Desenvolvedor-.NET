using VestibularApi.Domain.Entities;
using VestibularApi.Domain.Repositories.Interfaces;
using VestibularApi.API.Requests;
using VestibularApi.API.Responses;
using VestibularApi.Application.Services.Interfaces;
using VestibularApi.Domain.Repositories;

namespace VestibularApi.Application.Services.Implementations
{
    public class ProcessoSeletivoService : IProcessoSeletivoService
    {
        private readonly IProcessoSeletivoRepository _processoSeletivoRepository;

        public ProcessoSeletivoService(IProcessoSeletivoRepository processoSeletivoRepository)
        {
            _processoSeletivoRepository = processoSeletivoRepository;
        }

        public async Task<IEnumerable<ProcessoSeletivoResponse>> ObterTodosAsync()
        {
            var processosSeletivos = await _processoSeletivoRepository.PegarTodosAsync();
            return processosSeletivos.Select(p => new ProcessoSeletivoResponse(p.Id, p.Nome, p.DataInicio, p.DataTermino));
        }

        public async Task<ProcessoSeletivoResponse> ObterPorIdAsync(Guid id)
        {
            var processoSeletivo = await _processoSeletivoRepository.PegarPorIdAsync(id);

            if (processoSeletivo == null)
            {
                throw new KeyNotFoundException("Processo Seletivo não encontrado.");
            }

            return new ProcessoSeletivoResponse(processoSeletivo.Id, processoSeletivo.Nome, processoSeletivo.DataInicio, processoSeletivo.DataTermino);
        }

        public async Task<ProcessoSeletivoResponse> CriarAsync(ProcessoSeletivoRequest processoSeletivoRequest)
        {
            if (processoSeletivoRequest == null)
            {
                throw new ArgumentNullException(nameof(processoSeletivoRequest));
            }

            var processoSeletivo = new ProcessoSeletivoEntities(processoSeletivoRequest.Nome, processoSeletivoRequest.DataInicio, processoSeletivoRequest.DataTermino);
            await _processoSeletivoRepository.AdicionarAsync(processoSeletivo);

            return new ProcessoSeletivoResponse(processoSeletivo.Id, processoSeletivo.Nome, processoSeletivo.DataInicio, processoSeletivo.DataTermino);
        }

        public async Task AtualizarAsync(Guid id, ProcessoSeletivoRequest processoSeletivoRequest)
        {
            if (processoSeletivoRequest == null)
            {
                throw new ArgumentNullException(nameof(processoSeletivoRequest));
            }

            var processoSeletivo = await _processoSeletivoRepository.PegarPorIdAsync(id);

            if (processoSeletivo == null)
            {
                throw new KeyNotFoundException("Processo Seletivo não encontrado.");
            }

            processoSeletivo.Atualizar(processoSeletivoRequest.Nome, processoSeletivoRequest.DataInicio, processoSeletivoRequest.DataTermino);

            await _processoSeletivoRepository.AtualizarAsync(processoSeletivo);
        }

        public async Task DeletarAsync(Guid id)
        {
            var processoSeletivo = await _processoSeletivoRepository.PegarPorIdAsync(id);

            if (processoSeletivo == null)
            {
                throw new KeyNotFoundException("Processo Seletivo não encontrado.");
            }

            await _processoSeletivoRepository.DeletarAsync(id);
        }
    }
}
