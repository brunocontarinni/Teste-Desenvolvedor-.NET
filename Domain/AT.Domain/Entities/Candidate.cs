using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AT.Domain.Entities
{
    public class Candidate
    {
        public Candidate()
        {
            Inscription = [];
        }

        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(120)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(16)]
        public string Phone { get; set; } = string.Empty;
        [Required]
        [StringLength(14)]
        public string PersonalNumber { get; set; } = string.Empty;

        [InverseProperty("Candidate")]
        [JsonIgnore]
        public virtual ICollection<Inscription> Inscription { get; set; }
    }
}