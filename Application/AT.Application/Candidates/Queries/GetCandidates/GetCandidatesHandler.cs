using AT.Application.Candidates.Queries.GetCandidates.Request;
using AT.Application.Candidates.Queries.GetCandidates.Response;
using AT.Domain.Repositories.Candidates;
using MediatR;

namespace AT.Application.Candidates.Queries.GetCandidates
{
    public class GetCandidatesHandler(ICandidatesRepository candidatesRepository) : IRequestHandler<GetCandidatesRequest, GetCandidatesResponse>
    {
        private readonly ICandidatesRepository _candidateRepository = candidatesRepository;

        public async Task<GetCandidatesResponse> Handle(GetCandidatesRequest request, CancellationToken cancellationToken)
        {
            var course = await _candidateRepository.GetAsync(request.Id);
            var responses = new GetCandidatesResponse
            {
                Id = course!.Id,
                Name = course.Name,
                Email = course.Email,
                Phone = course.Phone,
                PersonalNumber = course.PersonalNumber
            };

            return responses;
        }
    }
}