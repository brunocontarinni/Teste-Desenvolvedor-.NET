using System.ComponentModel.DataAnnotations;

namespace testeCRMEDU.Models.Dtos
{
    public class OfertaDto
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int VagasDisponiveis { get; set; }
    }
}
