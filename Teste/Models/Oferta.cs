using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Teste.Models
{
    public class Oferta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOferta { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int? Vagas { get; set; }
    }
}
