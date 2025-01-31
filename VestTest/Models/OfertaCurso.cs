using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

public class OfertaCurso
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Nome { get; set; }

    [Required]
    [StringLength(500)]
    public string Descricao { get; set; }

    [Required]
    public int VagasDisponiveis { get; set; }

    public List<Inscricao> Inscricoes { get; set; } = new();
}
