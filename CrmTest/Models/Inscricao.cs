using System.ComponentModel.DataAnnotations;

namespace CrmTest.Models
{
    public class Inscricao
    {
        [Key]
        public int Id { get; set; }
        public required int N_inscricao { get; set; }
        public required DateTime Dt_inscricao { get; set; }
        public required int Status { get; set; }
        public int ofertaId { get; set; }
        public int leadId { get; set; }
        public int processo_seletivoId { get; set; }

    }
}

