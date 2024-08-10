using MediatR;

namespace AT.Application.Candidates.Commands.DeleteCandidates.Request
{
    public class DeleteCandidatesRequest : IRequest
    {
        public long Id { get; set; }
    }
}