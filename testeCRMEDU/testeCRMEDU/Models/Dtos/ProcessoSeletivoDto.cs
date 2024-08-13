using System.ComponentModel.DataAnnotations;

namespace testeCRMEDU.Models.Dtos
{
    public class ProcessoSeletivoDto
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataTermino { get; set; }
    }
}
