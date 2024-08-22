using System.ComponentModel.DataAnnotations;

namespace VestibularApi.API.Requests
{
    public class LeadRequest
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [EmailAddress(ErrorMessage = "Formato de email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório")]
        [Phone(ErrorMessage = "Formato de telefone inválido")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(11, ErrorMessage = "O CPF deve conter 11 caracteres")]
        public string CPF { get; set; }
    }
}
