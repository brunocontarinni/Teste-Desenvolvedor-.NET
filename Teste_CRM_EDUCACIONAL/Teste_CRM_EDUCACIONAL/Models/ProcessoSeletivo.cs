using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Teste_CRM_EDUCACIONAL.Models
{
    public class ProcessoSeletivo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        public DateTime DataDeInicio { get; set; }

        [Required]
        public DateTime DataDeTermino { get; set; }

        [JsonIgnore]
        public ICollection<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();
    }
}
