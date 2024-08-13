using System.ComponentModel.DataAnnotations;

namespace testeCRMEDU.Models.Dtos
{
    public class InscricaoDto
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public int NumeroInscricao { get; set; }
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public int Status { get; set; }
        [Required]
        public string LeadId { get; set; }
        [Required]
        public string ProcessoSeletivoId { get; set; }
        [Required]
        public string OfertaId { get; set; }
    }
}
