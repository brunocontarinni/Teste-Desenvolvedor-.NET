using AT.Application.Inscriptions.Commands.UpdateInscriptions.Request;
using AT.Domain.Entities;
using AT.Domain.Repositories.Inscriptions;
using MediatR;

namespace AT.Application.Inscriptions.Commands.UpdateInscriptions
{
    public class UpdateInscriptionsHandler(IInscriptionsRepository inscriptionsRepository) : IRequestHandler<UpdateInscriptionsRequest>
    {
        private readonly IInscriptionsRepository _inscriptionsRepository = inscriptionsRepository;

        public async Task Handle(UpdateInscriptionsRequest request, CancellationToken cancellationToken)
        {
            var updateTo = new Inscription
            {
                Id = request.Id,
                Status = request.Status,
                CandidateId = request.CandidateId,
                SelectionProcessId = request.SelectionProcessId,
                CourseId = request.CourseId
            };

            await _inscriptionsRepository.UpdateAsync(updateTo);
        }
    }
}