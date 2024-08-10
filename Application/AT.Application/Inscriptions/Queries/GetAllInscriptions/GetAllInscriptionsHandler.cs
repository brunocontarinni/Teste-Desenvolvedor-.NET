using AT.Application.Inscriptions.Queries.GetAllInscriptions.Request;
using AT.Application.Inscriptions.Queries.GetAllInscriptions.Responses;
using AT.Domain.Repositories.Inscriptions;
using MediatR;

namespace AT.Application.Inscriptions.Queries.GetAllInscriptions
{
    public class GetAllInscriptionsHandler(IInscriptionsRepository inscriptionsRepository) : IRequestHandler<GetAllInscriptionsRequest, IEnumerable<GetAllInscriptionsResponse>>
    {
        private readonly IInscriptionsRepository _inscritionsRepository = inscriptionsRepository;

        public async Task<IEnumerable<GetAllInscriptionsResponse>> Handle(GetAllInscriptionsRequest request, CancellationToken cancellationToken)
        {
            var inscriptions = await _inscritionsRepository.GetAllAsync();
            var response = inscriptions.Where(c => string.IsNullOrEmpty(request.Term) ||
                                                   c.NumberInscription.Trim().Contains(request.Term, StringComparison.CurrentCultureIgnoreCase) ||
                                                   c.Candidate.PersonalNumber.Trim().Contains(request.Term, StringComparison.CurrentCultureIgnoreCase))
                                       .Select(res => new GetAllInscriptionsResponse
                                       {
                                           Id = res.Id,
                                           NumberInscription = res.NumberInscription,
                                           CreationAt = res.CreationAt,
                                           Status = res.Status,
                                           CandidateName = res.Candidate.Name,
                                           SelectionProcessName = res.SelectionProcess.Name,
                                           SelectionProcessStart = res.SelectionProcess.StartDate,
                                           SelectionProcessEnd = res.SelectionProcess.EndDate,
                                           CourseName = res.Course.Name,
                                           AvailableVacancies = res.Course.AvailableVacancies
                                       });
            return response;
        }
    }
}