using CrmTest.Models;

namespace CrmTest.DTO
{
    public class InscricaoDTO()
    {
        public int Id { get; set; }
        public int N_inscricao { get; set; }
        public DateTime Dt_inscricao { get; set; }
        public int Status { get; set; }
        public int ofertaId { get; set; }
        public int leadId { get; set; }
        public int processo_seletivoId { get; set; }
    }
}