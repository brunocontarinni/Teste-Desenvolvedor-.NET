
using System.ComponentModel.DataAnnotations;

namespace VestibularApi.Domain.Entities
{
    public class Lead
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        public string Telefone { get; set; }

        [Required]
        [StringLength(11, ErrorMessage = "O CPF deve conter 11 caracteres.")]
        public string CPF { get; set; }

        public ICollection<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();

        public Lead()
        {
        }

        public Lead(string nome, string email, string telefone, string cpf)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            CPF = cpf;
        }
    }
}
