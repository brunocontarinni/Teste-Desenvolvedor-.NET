using System.ComponentModel.DataAnnotations;

namespace Teste.Models
{
    public class Lead
    {
        [Key]
        public int IdLead { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Por favor, insira um endereço de email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [Phone(ErrorMessage = "Por favor, insira um número de telefone válido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(11, ErrorMessage = "O CPF deve ter 11 dígitos")]
        public string CPF { get; set; }
    }}
