using AT.Application.Candidates.Queries.GetCandidates.Response;
using MediatR;

namespace AT.Application.Candidates.Queries.GetCandidates.Request
{
    public class GetCandidatesRequest : IRequest<GetCandidatesResponse>
    {
        public long Id { get; set; }
    }
}