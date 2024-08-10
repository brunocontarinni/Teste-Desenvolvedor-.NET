using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AT.Domain.Entities
{
    public class Course
    {
        public Course()
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
        public string Description { get; set; } = string.Empty;
        [Required]
        public int AvailableVacancies { get; set; }

        [InverseProperty("Course")]
        [JsonIgnore]
        public virtual ICollection<Inscription> Inscription { get; set; }
    }
}