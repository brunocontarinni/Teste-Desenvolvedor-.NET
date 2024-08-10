using AT.Application.SelectionProcesses.Queries.GetSelectionProcesses.Responses;
using MediatR;

namespace AT.Application.SelectionProcesses.Queries.GetSelectionProcesses.Request
{
    public class GetSelectionProcessesRequest : IRequest<GetSelectionProcessesResponse>
    {
        public long Id { get; set; }
    }
}