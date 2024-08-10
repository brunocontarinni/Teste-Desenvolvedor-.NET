using AT.Application.Candidates.Commands.AddCandidate.Request;
using AT.Domain.Entities;
using AT.Domain.Repositories.Candidates;
using MediatR;

namespace AT.Application.Candidates.Commands.AddCandidate
{
    public class AddCandidatesHandler(ICandidatesRepository candidatesRepository) : IRequestHandler<AddCandidatesRequest>
    {
        private readonly ICandidatesRepository _candidatesRepository = candidatesRepository;

        public async Task Handle(AddCandidatesRequest request, CancellationToken cancellationToken)
        {
            var addTo = new Candidate
            {
                Name = request.Name,
                Email = request.Email,
                Phone = request.Phone,
                PersonalNumber = request.PersonalNumber
            };

            await _candidatesRepository.CreateAsync(addTo);
        }
    }
}
