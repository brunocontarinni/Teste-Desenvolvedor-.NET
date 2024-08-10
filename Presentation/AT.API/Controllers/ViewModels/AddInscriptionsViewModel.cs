namespace AT.API.Controllers.ViewModels
{
    public class AddInscriptionsViewModel
    {
        public bool Status { get; set; } = false;
        public long CandidateId { get; set; }
        public long SelectionProcessId { get; set; }
        public long CourseId { get; set; }
    }
}