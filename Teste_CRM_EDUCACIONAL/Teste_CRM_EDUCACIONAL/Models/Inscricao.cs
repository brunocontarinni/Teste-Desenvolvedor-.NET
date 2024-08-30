using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste_CRM_EDUCACIONAL.Models
{
    public class Inscricao
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int NumeroDeInscricao { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [Required]
        [ForeignKey("Lead")]
        public int LeadId { get; set; }
        public Lead Lead { get; set; }

        [Required]
        [ForeignKey("ProcessoSeletivo")]
        public int ProcessoSeletivoId { get; set; }
        public ProcessoSeletivo ProcessoSeletivo { get; set; }

        [Required]
        [ForeignKey("Oferta")]
        public int OfertaId { get; set; }
        public Oferta Oferta { get; set; }
    }
}
