using AT.Application.SelectionProcesses.Commands.AddSelectionProcesses.Request;
using AT.Domain.Entities;
using AT.Domain.Repositories.SelectionProcesses;
using MediatR;

namespace AT.Application.SelectionProcesses.Commands.AddSelectionProcesses
{
    public class AddSelectionProcessesHandler(ISelectionProcessesRepository selectionProcessesRepository) : IRequestHandler<AddSelectionProcessesRequest>
    {
        private readonly ISelectionProcessesRepository _selectionProcessesRepository = selectionProcessesRepository;

        public async Task Handle(AddSelectionProcessesRequest request, CancellationToken cancellationToken)
        {
            var addTo = new SelectionProcess
            {
                Name = request.Name,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };

            await _selectionProcessesRepository.CreateAsync(addTo);
        }
    }
}