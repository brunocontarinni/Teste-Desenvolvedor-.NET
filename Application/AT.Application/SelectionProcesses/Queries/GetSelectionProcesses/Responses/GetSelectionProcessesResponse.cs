namespace AT.Application.SelectionProcesses.Queries.GetSelectionProcesses.Responses
{
    public class GetSelectionProcessesResponse
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}