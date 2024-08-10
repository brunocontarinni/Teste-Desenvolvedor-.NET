using AT.Application.SelectionProcesses.Commands.UpdateSelectionProcesses.Request;
using AT.Domain.Entities;
using AT.Domain.Repositories.SelectionProcesses;
using MediatR;

namespace AT.Application.SelectionProcesses.Commands.UpdateSelectionProcesses
{
    public class UpdateSelectionProcessesHandler(ISelectionProcessesRepository selectionProcessesRepository) : IRequestHandler<UpdateSelectionProcessesRequest>
    {
        private readonly ISelectionProcessesRepository _selectionProcessesRepository = selectionProcessesRepository;

        public async Task Handle(UpdateSelectionProcessesRequest request, CancellationToken cancellationToken)
        {
            var updateTo = new SelectionProcess
            {
                Id = request.Id,
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };

            await _selectionProcessesRepository.UpdateAsync(updateTo);
        }
    }
}