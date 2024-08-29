using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lucas_gabriel_api.Models.Entitys;

public class Oferta
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome precisa estar preenchido")]
    [StringLength(150, ErrorMessage = "O nome não pode ter mais de 150 caracteres")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Descricao precisa estar preenchido")]
    [StringLength(250, ErrorMessage = "O descricao não pode ter mais de 250 caracteres")]
    public string Descricao { get; set; } = string.Empty;

    [Range(0, int.MaxValue, ErrorMessage = "O nome não pode ter mais de 150 caracteres")]
    public int VagasDisponiveis { get; set; } = 0;

}