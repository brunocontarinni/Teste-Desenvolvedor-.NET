using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lucas_gabriel_api.Models.Entitys;


public class Lead
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome precisa estar preenchido")]
    [StringLength(150, ErrorMessage = "O nome não pode ter mais de 150 caracteres")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email precisa estar preenchido")]
    [EmailAddress(ErrorMessage = "Formato de email inválido")]
    [StringLength(100, ErrorMessage = "O email não pode ter mais de 100 caracteres")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Telefone precisa estar preenchido")]
    [StringLength(12, MinimumLength = 10, ErrorMessage = "O nome não pode ter mais de 12 caracterese nem menos 10 numeros")]
    [RegularExpression(@"^\d+$", ErrorMessage = "O campo Telefone precisa conter somente números")]
    public string Telefone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Cpf precisa estar preenchido")]
    [RegularExpression(@"^\d{11}$", ErrorMessage = "O campo Cpf precisa ter exatamente 11 numeros")]
    public string Cpf { get; set; } = string.Empty;

}