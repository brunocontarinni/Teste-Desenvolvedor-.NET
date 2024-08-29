namespace Teste_CRM_EDUCACIONAL.DTOs
{
    public class InscricaoDto
    {
        public int Id { get; set; }
        public int NumeroDeInscricao { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public int LeadId { get; set; }
        public int ProcessoSeletivoId { get; set; }
        public int OfertaId { get; set; }
    }
}
