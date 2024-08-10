using AT.Application.Candidates.Commands.DeleteCandidates.Request;
using AT.Domain.Repositories.Candidates;
using MediatR;

namespace AT.Application.Candidates.Commands.DeleteCandidates
{
    public class DeleteCandidatesHandler(ICandidatesRepository candidatesRepository) : IRequestHandler<DeleteCandidatesRequest>
    {
        private readonly ICandidatesRepository _candidatesRepository = candidatesRepository;

        public async Task Handle(DeleteCandidatesRequest request, CancellationToken cancellationToken)
        {
            await _candidatesRepository.DeleteAsync(request.Id);
        }
    }
}