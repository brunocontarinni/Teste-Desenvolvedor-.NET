using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AT.Domain.Entities
{
    public class Inscription
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public string NumberInscription { get; set; } = string.Empty;
        [Required]
        public DateTime CreationAt { get; set; }
        [Required]
        public bool Status { get; set; } = false;
        [Required]
        public long CandidateId { get; set; }
        [Required]
        public long SelectionProcessId { get; set; }
        [Required]
        public long CourseId { get; set; }

        [Required]
        [ForeignKey(nameof(CandidateId))]
        public virtual Candidate Candidate { get; set; } = new();
        [Required]
        [ForeignKey(nameof(SelectionProcessId))]
        public virtual SelectionProcess SelectionProcess { get; set; } = new();
        [Required]
        [ForeignKey(nameof(CourseId))]
        public virtual Course Course { get; set; } = new();
    }
}