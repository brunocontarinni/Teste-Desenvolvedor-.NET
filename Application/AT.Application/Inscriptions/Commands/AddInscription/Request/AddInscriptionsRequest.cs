using MediatR;

namespace AT.Application.Inscriptions.Commands.AddInscription.Request
{
    public class AddInscriptionsRequest : IRequest
    {
        public bool Status { get; set; } = false;
        public long CandidateId { get; set; }
        public long SelectionProcessId { get; set; }
        public long CourseId { get; set; }
    }
}