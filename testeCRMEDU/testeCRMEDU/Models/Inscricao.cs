namespace testeCRMEDU.Models
{
    public class Inscricao
    {
        public string Id { get; set; }
        public int NumeroInscricao { get; set; }
        public DateTime Data { get; set; }
        public int Status { get; set; }
        public string LeadId { get; set; }
        public string ProcessoSeletivoId { get; set; }
        public string OfertaId { get; set; }

    }
}
