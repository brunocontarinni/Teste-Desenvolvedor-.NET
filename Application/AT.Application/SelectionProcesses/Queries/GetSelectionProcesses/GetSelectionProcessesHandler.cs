using AT.Application.Courses.Queries.GetAllCourses.Responses;
using AT.Application.SelectionProcesses.Queries.GetSelectionProcesses.Request;
using AT.Application.SelectionProcesses.Queries.GetSelectionProcesses.Responses;
using AT.Domain.Repositories.SelectionProcesses;
using MediatR;

namespace AT.Application.SelectionProcesses.Queries.GetSelectionProcesses
{
    public class GetSelectionProcessesHandler(ISelectionProcessesRepository selectionProcessesRepository) : IRequestHandler<GetSelectionProcessesRequest, GetSelectionProcessesResponse>
    {
        private readonly ISelectionProcessesRepository _selectionProcessesRepository = selectionProcessesRepository;

        public async Task<GetSelectionProcessesResponse> Handle(GetSelectionProcessesRequest request, CancellationToken cancellationToken)
        {
            var selectionProcess = await _selectionProcessesRepository.GetAsync(request.Id);
            var responses = new GetSelectionProcessesResponse
            {
                Id = selectionProcess!.Id,
                Name = selectionProcess.Name,
                StartDate = selectionProcess.StartDate,
                EndDate = selectionProcess.EndDate
            };

            return responses;
        }
    }
}