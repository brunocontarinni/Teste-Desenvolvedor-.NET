using System.ComponentModel.DataAnnotations;

namespace VestibularApi.Models
{
    /// <summary>
    /// Representa um candidato inscrito no processo seletivo.
    /// </summary>
    public class Candidato
    {
        /// <summary>
        /// Identificador único do candidato.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome completo do candidato.
        /// </summary>
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; }

        /// <summary>
        /// Endereço de email do candidato.
        /// </summary>
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        public string Email { get; set; }

        /// <summary>
        /// Número de telefone do candidato.
        /// </summary>
        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [Phone(ErrorMessage = "Formato de telefone inválido.")]
        public string Telefone { get; set; }

        /// <summary>
        /// CPF (Cadastro de Pessoa Física) do candidato, no formato XXX.XXX.XXX-XX.
        /// </summary>
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Formato de CPF inválido. Use o formato XXX.XXX.XXX-XX.")]
        public string CPF { get; set; }

        /// <summary>
        /// Indica se o candidato está ativo. Usado para soft delete.
        /// </summary>
        public bool IsActive { get; set; } = true;  // Flag para soft delete
    }
}
