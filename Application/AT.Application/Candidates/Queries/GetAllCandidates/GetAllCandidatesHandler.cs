using AT.Application.Candidates.Queries.GetAllCandidates.Request;
using AT.Application.Candidates.Queries.GetAllCandidates.Responses;
using AT.Domain.Repositories.Candidates;
using MediatR;

namespace AT.Application.Candidates.Queries.GetAllCandidates
{
    public class GetAllCandidatesHandler(ICandidatesRepository candidatesRepository) : IRequestHandler<GetAllCandidatesRequest, IEnumerable<GetAllCandidatesResponse>>
    {
        private readonly ICandidatesRepository _candidatesRepository = candidatesRepository;

        public async Task<IEnumerable<GetAllCandidatesResponse>> Handle(GetAllCandidatesRequest request, CancellationToken cancellationToken)
        {
            var candidates = await _candidatesRepository.GetAllAsync();
            var responses = candidates.Where(c => string.IsNullOrWhiteSpace(request.Term) ||
                                          c.Name.Trim().Contains(request.Term, StringComparison.CurrentCultureIgnoreCase)).Select(res => new GetAllCandidatesResponse
                                          {
                                              Id = res.Id,
                                              Name = res.Name,
                                              Email = res.Email,
                                              Phone = res.Phone,
                                              PersonalNumber = res.PersonalNumber
                                          }).ToList();
            return responses;
        }
    }
}