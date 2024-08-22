using System.ComponentModel.DataAnnotations;

namespace VestibularApi.API.Requests
{
    public class OfertaRequest
    {
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [MaxLength(500)]
        public string Descricao { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataFim { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "O número de vagas disponíveis deve ser maior que zero.")]
        public int VagasDisponiveis { get; set; }
    }
}
