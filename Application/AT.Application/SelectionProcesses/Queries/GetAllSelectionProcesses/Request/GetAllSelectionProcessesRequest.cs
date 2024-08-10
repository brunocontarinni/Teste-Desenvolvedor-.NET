using AT.Application.SelectionProcesses.Queries.GetAllSelectionProcesses.Responses;
using MediatR;

namespace AT.Application.SelectionProcesses.Queries.GetAllSelectionProcesses.Request
{
    public class GetAllSelectionProcessesRequest : IRequest<IEnumerable<GetAllSelectionProcessesResponse>>
    {
        public string? Term { get; set; }
    }
}