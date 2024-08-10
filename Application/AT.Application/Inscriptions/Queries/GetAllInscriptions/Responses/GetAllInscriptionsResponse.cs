namespace AT.Application.Inscriptions.Queries.GetAllInscriptions.Responses
{
    public class GetAllInscriptionsResponse
    {
        public long Id { get; set; }
        public string NumberInscription { get; set; } = string.Empty;
        public DateTime CreationAt { get; set; }
        public bool Status { get; set; } = false;
        public string CandidateName { get; set; } = string.Empty;
        public string SelectionProcessName { get; set; } = string.Empty;
        public DateTime SelectionProcessStart { get; set; }
        public DateTime SelectionProcessEnd { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public int AvailableVacancies { get; set; } = 0;
    }
}