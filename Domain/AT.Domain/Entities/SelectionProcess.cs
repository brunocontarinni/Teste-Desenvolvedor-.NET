using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AT.Domain.Entities
{
    public class SelectionProcess
    {
        public SelectionProcess()
        {
            Inscription = [];
        }
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(60)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }

        [InverseProperty("SelectionProcess")]
        [JsonIgnore]
        public virtual ICollection<Inscription> Inscription { get; set; }
    }
}