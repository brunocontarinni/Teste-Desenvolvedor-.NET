using AT.Application.Inscriptions.Queries.GetInscriptions.Request;
using AT.Application.Inscriptions.Queries.GetInscriptions.Response;
using AT.Domain.Repositories.Inscriptions;
using MediatR;

namespace AT.Application.Inscriptions.Queries.GetInscriptions
{
    public class GetInscriptionsHandler(IInscriptionsRepository inscriptionsRepository) : IRequestHandler<GetInscriptionsRequest, GetInscriptionsResponse>
    {
        private readonly IInscriptionsRepository _inscriptionsRepository = inscriptionsRepository;

        public async Task<GetInscriptionsResponse> Handle(GetInscriptionsRequest request, CancellationToken cancellationToken)
        {
            var inscriptions = await _inscriptionsRepository.GetAsync(request.Id);
            var response = new GetInscriptionsResponse
            {
                Id = inscriptions!.Id,
                NumberInscription = inscriptions.NumberInscription,
                CreationAt = inscriptions.CreationAt,
                Status = inscriptions.Status,
                Candidate = inscriptions.Candidate,
                SelectionProcess = inscriptions.SelectionProcess,
                Course = inscriptions.Course
            };

            return response;
        }
    }
}