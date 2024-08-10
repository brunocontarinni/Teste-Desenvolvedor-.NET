using AT.Application.SelectionProcesses.Queries.GetAllSelectionProcesses.Request;
using AT.Application.SelectionProcesses.Queries.GetAllSelectionProcesses.Responses;
using AT.Domain.Repositories.SelectionProcesses;
using MediatR;

namespace AT.Application.SelectionProcesses.Queries.GetAllSelectionProcesses
{
    public class GetAllSelectionProcessesHandler(ISelectionProcessesRepository selectionProcessesRepository) : IRequestHandler<GetAllSelectionProcessesRequest, IEnumerable<GetAllSelectionProcessesResponse>>
    {
        private readonly ISelectionProcessesRepository _selectionProcessesRepository = selectionProcessesRepository;

        public async Task<IEnumerable<GetAllSelectionProcessesResponse>> Handle(GetAllSelectionProcessesRequest request, CancellationToken cancellationToken)
        {
            var selectionProcesses = await _selectionProcessesRepository.GetAllAsync();
            var responses = selectionProcesses.Where(c => string.IsNullOrWhiteSpace(request.Term) ||
                                          c.Name.Trim().Contains(request.Term, StringComparison.CurrentCultureIgnoreCase)).Select(res => new GetAllSelectionProcessesResponse
                                          {
                                              Id = res.Id,
                                              Name = res.Name,
                                              StartDate = res.StartDate,
                                              EndDate = res.EndDate
                                          }).ToList();
            return responses;
        }
    }
}