using System;

public class InscricaoDTO
{
    public int Id { get; set; }
    public int NumeroInscricao { get; set; }
    public DateTime Data { get; set; }
    public bool Status { get; set; }
    public int CandidatoId { get; set; }
    public string CandidatoNome { get; set; }  // Novo campo
    public string CandidatoCpf { get; set; }   // Novo campo
    public int ProcessoSeletivoId { get; set; }
    public string ProcessoSeletivoNome { get; set; }  // Novo campo
    public int OfertaCursoId { get; set; }
    public string OfertaCursoNome { get; set; }  // Novo campo
}
