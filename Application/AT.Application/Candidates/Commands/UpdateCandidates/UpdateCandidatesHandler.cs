using AT.Application.Candidates.Commands.UpdateCandidates.Request;
using AT.Domain.Entities;
using AT.Domain.Repositories.Candidates;
using MediatR;

namespace AT.Application.Candidates.Commands.UpdateCandidates
{
    public class UpdateCandidatesHandler(ICandidatesRepository candidatesRepository) : IRequestHandler<UpdateCandidatesRequest>
    {
        private readonly ICandidatesRepository _candidatesRepository = candidatesRepository;

        public async Task Handle(UpdateCandidatesRequest request, CancellationToken cancellationToken)
        {
            var updateTo = new Candidate
            {
                Id = request.Id,
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                PersonalNumber = request.PersonalNumber
            };

            await _candidatesRepository.UpdateAsync(updateTo);
        }
    }
}