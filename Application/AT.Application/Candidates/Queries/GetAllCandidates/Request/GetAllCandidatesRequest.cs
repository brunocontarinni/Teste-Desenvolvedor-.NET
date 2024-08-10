using AT.Application.Candidates.Queries.GetAllCandidates.Responses;
using MediatR;

namespace AT.Application.Candidates.Queries.GetAllCandidates.Request
{
    public class GetAllCandidatesRequest : IRequest<IEnumerable<GetAllCandidatesResponse>>
    {
        public string? Term { get; set; }
    }
}