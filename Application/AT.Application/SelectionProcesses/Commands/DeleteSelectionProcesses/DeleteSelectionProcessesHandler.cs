using AT.Domain.Repositories.SelectionProcesses;
using MediatR;

namespace AT.Application.SelectionProcesses.Commands.DeleteSelectionProcesses
{
    public class DeleteSelectionProcessesHandler(ISelectionProcessesRepository selectionProcessesRepository) : IRequestHandler<DeleteSelectionProcessesRequest>
    {
        private readonly ISelectionProcessesRepository _selectionProcess = selectionProcessesRepository;

        public async Task Handle(DeleteSelectionProcessesRequest request, CancellationToken cancellationToken)
        {
            await _selectionProcess.DeleteAsync(request.ID);
        }
    }
}