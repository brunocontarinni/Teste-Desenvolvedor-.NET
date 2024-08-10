using MediatR;

namespace AT.Application.SelectionProcesses.Commands.AddSelectionProcesses.Request
{
    public class AddSelectionProcessesRequest : IRequest
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}