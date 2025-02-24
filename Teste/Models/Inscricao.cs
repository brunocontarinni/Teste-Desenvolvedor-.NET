using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.Models
{
    [Table("Inscricao")]
    public class Inscricao
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("numeroinscricao")]
        [DisplayName("Número da Inscrição")]
        public required int NumeroInscricao { get; set; }

        [Column("datainscricao")]
        [DisplayName("Data da Inscrição")]
        public DateTime Data { get; set; }

        [Column("status")]
        public required string Status { get; set; }

        [Column("cpf")]
        public required string CPF { get; set; }

        [Column("id_lead")]
        [ForeignKey("lead_id")]
        public int IdLead { get; set; }

        [Column("id_processoseletivo")]
        [ForeignKey("processoseletivo_id")]
        public int IdProcessoseletivo { get; set; }

        [Column("id_oferta")]
        [ForeignKey("oferta_id")]
        public int IdOferta { get; set; }
    }
}
