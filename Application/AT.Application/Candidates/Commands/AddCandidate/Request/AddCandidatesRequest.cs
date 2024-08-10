using MediatR;

namespace AT.Application.Candidates.Commands.AddCandidate.Request
{
    public class AddCandidatesRequest : IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string PersonalNumber { get; set; } = string.Empty;
    }
}