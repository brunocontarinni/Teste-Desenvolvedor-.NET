using System.ComponentModel.DataAnnotations;

namespace VestibularApi.Domain.Entities
{
    public class LeadEntities
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

        public ICollection<InscricaoEntities> Inscricoes { get; set; } = new List<InscricaoEntities>();

        public LeadEntities()
        {
        }

        public LeadEntities(string nome, string email, string telefone, string cpf)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            CPF = cpf;
        }

        public void Atualizar(string nome, string email, string telefone, string cpf)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            CPF = cpf;
        }
    }
}
