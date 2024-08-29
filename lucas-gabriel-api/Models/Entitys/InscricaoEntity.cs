using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lucas_gabriel_api.Models.Entitys;

public class Inscricao
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required(ErrorMessage = "Numero de Inscrição precisa estar preenchido")]
    [StringLength(8, ErrorMessage = "O numero de inscrição não pode ter mais de 8 caracteres")]
    [RegularExpression(@"^\d+$", ErrorMessage = "O campo Telefone precisa conter somente números")]
    public string NumeroInscricao { get; set; } = string.Empty;

    [Required(ErrorMessage = "Data precisa estar preenchida")]
    [Column(TypeName = "date")]
    [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm:ss}", ApplyFormatInEditMode = true)]
    public DateTime Data { get; set; }

    [Required(ErrorMessage = "Status precisa estar preenchido")]
    public Boolean Status { get; set; } = false;

    [Required(ErrorMessage = "LeadId precisa estar preenchido")]
    [ForeignKey("Lead")]
    public int LeadId { get; set; }
    public Lead? Lead { get; set; }

    [Required(ErrorMessage = "OfertaId precisa estar preenchido")]
    [ForeignKey("Oferta")]
    public int OfertaId { get; set; }
    public Oferta? Oferta { get; set; }

    [Required(ErrorMessage = "ProcessoSeletivoId precisa estar preenchido")]
    [ForeignKey("ProcessoSeletivo")]
    public int ProcessoSeletivoId { get; set; }
    public ProcessoSeletivo? ProcessoSeletivo { get; set; }
}