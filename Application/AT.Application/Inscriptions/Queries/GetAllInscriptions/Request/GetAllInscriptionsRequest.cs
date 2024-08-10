using AT.Application.Inscriptions.Queries.GetAllInscriptions.Responses;
using MediatR;

namespace AT.Application.Inscriptions.Queries.GetAllInscriptions.Request
{
    public class GetAllInscriptionsRequest : IRequest<IEnumerable<GetAllInscriptionsResponse>>
    {
        public string? Term { get; set; }
    }
}