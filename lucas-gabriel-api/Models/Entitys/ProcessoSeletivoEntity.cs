using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lucas_gabriel_api.Models.Entitys;

public class ProcessoSeletivo
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Nome precisa estar preenchido")]
    [StringLength(150, ErrorMessage = "O nome não pode ter mais de 150 caracteres")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "Data Inicio precisa estar preenchida")]
    [Column(TypeName = "date")]
    public DateTime DataInicio { get; set; }

    [Required(ErrorMessage = "Data Fim precisa estar preenchida")]
    [Column(TypeName = "date")]
    public DateTime DataFim { get; set; }
}