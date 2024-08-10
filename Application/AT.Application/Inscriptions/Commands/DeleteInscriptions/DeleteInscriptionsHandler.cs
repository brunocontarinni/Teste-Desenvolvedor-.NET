using AT.Application.Inscriptions.Commands.DeleteInscriptions.Request;
using AT.Domain.Repositories.Inscriptions;
using MediatR;

namespace AT.Application.Inscriptions.Commands.DeleteInscriptions
{
    public class DeleteInscriptionsHandler(IInscriptionsRepository inscriptionsRepository) : IRequestHandler<DeleteInscriptionsRequest>
    {
        private readonly IInscriptionsRepository _inscriptionsRepository = inscriptionsRepository;

        public async Task Handle(DeleteInscriptionsRequest request, CancellationToken cancellationToken)
        {
            await _inscriptionsRepository.DeleteAsync(request.Id);
        }
    }
}