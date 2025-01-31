namespace VestibularApi.Domain.Entities
{
    public class Inscricao
    {
        public int Id { get; set; }
        public string NumeroInscricao { get; set; } = string.Empty;
        public DateTime Data { get; set; }
        public string Status { get; set; } = string.Empty;

        public int LeadId { get; set; }
        public Lead? Lead { get; set; } = null!;

        public int ProcessoSeletivoId { get; set; }
        public ProcessoSeletivo? ProcessoSeletivo { get; set; } = null!;

        public int OfertaId { get; set; }
        public Oferta? Oferta { get; set; } = null!;
    }
}
