using MediatR;

namespace AT.Application.Inscriptions.Commands.UpdateInscriptions.Request
{
    public class UpdateInscriptionsRequest : IRequest
    {
        public long Id { get; set; }
        public bool Status { get; set; } = false;
        public long CandidateId { get; set; }
        public long SelectionProcessId { get; set; }
        public long CourseId { get; set; }
    }
}