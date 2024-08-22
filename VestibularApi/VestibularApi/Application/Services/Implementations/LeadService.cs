using VestibularApi.Domain.Entities;
using VestibularApi.Domain.Repositories;
using VestibularApi.API.Requests;
using VestibularApi.API.Responses;
using VestibularApi.Application.Services.Interfaces;

namespace VestibularApi.Application.Services.Implementations
{
    public class LeadService : ILeadService
    {
        private readonly ILeadRepository _leadRepository;

        public LeadService(ILeadRepository leadRepository)
        {
            _leadRepository = leadRepository;
        }

        public async Task<IEnumerable<LeadResponse>> ObterTodosAsync()
        {
            var leads = await _leadRepository.PegarTodosAsync();
            return leads.Select(l => new LeadResponse(l.Id, l.Nome, l.Email, l.Telefone, l.CPF));
        }

        public async Task<LeadResponse> ObterPorIdAsync(Guid id)
        {
            var lead = await _leadRepository.PegarPorIdAsync(id);

            if (lead == null)
            {
                throw new KeyNotFoundException("Lead não encontrado.");
            }

            return new LeadResponse(lead.Id, lead.Nome, lead.Email, lead.Telefone, lead.CPF);
        }

        public async Task<LeadResponse> CriarAsync(LeadRequest leadRequest)
        {
            if (leadRequest == null)
            {
                throw new ArgumentNullException(nameof(leadRequest));
            }

            var lead = new LeadEntities(leadRequest.Nome, leadRequest.Email, leadRequest.Telefone, leadRequest.CPF);
            await _leadRepository.AdicionarAsync(lead);

            return new LeadResponse(lead.Id, lead.Nome, lead.Email, lead.Telefone, lead.CPF);
        }

        public async Task AtualizarAsync(Guid id, LeadRequest leadRequest)
        {
            if (leadRequest == null)
            {
                throw new ArgumentNullException(nameof(leadRequest));
            }

            var lead = await _leadRepository.PegarPorIdAsync(id);

            if (lead == null)
            {
                throw new KeyNotFoundException("Lead não encontrado.");
            }

            lead.Atualizar(leadRequest.Nome, leadRequest.Email, leadRequest.Telefone, leadRequest.CPF);

            await _leadRepository.AtualizarAsync(lead);
        }

        public async Task DeletarAsync(Guid id)
        {
            var lead = await _leadRepository.PegarPorIdAsync(id);

            if (lead == null)
            {
                throw new KeyNotFoundException("Lead não encontrado.");
            }

            await _leadRepository.DeletarAsync(id);
        }
    }
}
