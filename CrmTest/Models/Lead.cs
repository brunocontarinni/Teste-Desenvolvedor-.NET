using System.ComponentModel.DataAnnotations;

namespace CrmTest.Models{
    public class Lead{
        [Key]
        public int Id { get; set; }
        [Required]
        public required string Nome { get; set; }
        [Required]
        public required string Email { get; set; }
        public string? Telefone { get; set; }
        public required string Cpf { get; set; }
    }
}