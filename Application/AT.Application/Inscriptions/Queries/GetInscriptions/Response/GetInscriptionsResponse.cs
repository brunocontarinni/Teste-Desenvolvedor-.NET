using AT.Domain.Entities;

namespace AT.Application.Inscriptions.Queries.GetInscriptions.Response
{
    public class GetInscriptionsResponse
    {
        public long Id { get; set; }
        public string NumberInscription { get; set; } = string.Empty;
        public DateTime CreationAt { get; set; }
        public bool Status { get; set; } = false;
        public Candidate Candidate { get; set; } = new Candidate();
        public SelectionProcess SelectionProcess { get; set; } = new SelectionProcess();
        public Course Course { get; set; } = new Course();
    }
}