namespace vestibular_info.Models
{
    public class Inscricao
    {
        public int Id { get; set; }
        public string? NumeroInscricao { get; set; }
        public DateTime Data { get; set; }
        public string? Status { get; set; }

        public int LeadId { get; set; }
        public Lead? Lead { get; set; }

        public int ProcessoSeletivoId { get; set; }
        public ProcessoSeletivo? ProcessoSeletivo { get; set; }

        public int OfertaId { get; set; }
        public Oferta? Oferta { get; set; }
    }
}
