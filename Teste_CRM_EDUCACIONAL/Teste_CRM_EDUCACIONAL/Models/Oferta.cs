using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Teste_CRM_EDUCACIONAL.Models
{
    public class Oferta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(500)]
        public string Descricao { get; set; }

        [Required]
        public int VagasDisponiveis { get; set; }

        [JsonIgnore]
        public ICollection<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();
    }
}
