using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.Models
{
    [Table("Lead")]
    public class Lead
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("nome")]
        public required string Nome { get; set; }

        [Column("descricao")]
        public required string Descricao { get; set; }

        [Column("vagasdisponiveis")]
        [DisplayName("Vagas Disponíveis")]
        public required int VagasDisponiveis { get; set; }
    }
}
