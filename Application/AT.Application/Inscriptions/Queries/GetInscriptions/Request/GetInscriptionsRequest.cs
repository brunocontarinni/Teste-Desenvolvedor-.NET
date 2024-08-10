using AT.Application.Inscriptions.Queries.GetInscriptions.Response;
using MediatR;

namespace AT.Application.Inscriptions.Queries.GetInscriptions.Request
{
    public class GetInscriptionsRequest : IRequest<GetInscriptionsResponse>
    {
        public long Id { get; set; }
    }
}