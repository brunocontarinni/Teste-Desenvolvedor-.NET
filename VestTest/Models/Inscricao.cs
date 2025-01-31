using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

public class Inscricao
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int NumeroInscricao { get; set; }

    [Required]
    public DateTime Data { get; set; }

    [Required]
    public bool Status { get; set; }

    [Required]
    [ForeignKey("CandidatoId")]
    public int CandidatoId { get; set; }
    public Candidato Candidato { get; set; }

    [Required]
    [ForeignKey("ProcessoSeletivoId")]
    public int ProcessoSeletivoId { get; set; }
    public ProcessoSeletivo ProcessoSeletivo { get; set; }

    [Required]
    [ForeignKey("OfertaCursoId")]
    public int OfertaCursoId { get; set; }
    public OfertaCurso OfertaCurso { get; set; }
}