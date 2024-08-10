namespace AT.Application.SelectionProcesses.Queries.GetAllSelectionProcesses.Responses
{
    public class GetAllSelectionProcessesResponse
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}