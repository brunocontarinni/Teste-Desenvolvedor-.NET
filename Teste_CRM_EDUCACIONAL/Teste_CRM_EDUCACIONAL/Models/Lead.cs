using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Teste_CRM_EDUCACIONAL.Models
{
    public class Lead
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; }

        [Required]
        [StringLength(11)]
        public string CPF { get; set; }

        [JsonIgnore]
        public ICollection<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();
    }
}
