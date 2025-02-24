using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.Models
{
    [Table("Oferta")]
    public class Oferta
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("nome")]
        public required string Nome { get; set; }

        [Column("email")]
        [EmailAddress(ErrorMessage = "Endereço de email inválido")]
        public required string Email { get; set; }

        [Column("telefone")]
        public required string Telefone { get; set; }
        
        [Column("cpf")]
        [StringLength(11)]
        public required string CPF { get; set; }        
    }
}
