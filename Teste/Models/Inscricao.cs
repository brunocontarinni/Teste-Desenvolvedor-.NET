using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Teste.Models
{
    public class Inscricao
    {
        [Key]
        public int IdInscricao { get; set; }
        public int? Numero { get; set; }
        public DateTime? Data { get; set; }
        public string Status { get; set; }

        [ForeignKey("Lead")]
        public int? IdLead { get; set; }
        public ProcessoSeletivo Lead { get; set; }

        [ForeignKey("Oferta")]
        public int? IdOferta { get; set; }
        public Oferta Oferta { get; set; }

        [ForeignKey("ProcessoSeletivo")]
        public int? IdProcessoSeletivo { get; set; }
        public ProcessoSeletivo ProcessoSeletivo { get; set; }
    }
}
