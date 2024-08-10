using MediatR;

namespace AT.Application.Inscriptions.Commands.DeleteInscriptions.Request
{
    public class DeleteInscriptionsRequest : IRequest
    {
        public long Id { get; set; }
    }
}