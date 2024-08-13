using System.ComponentModel.DataAnnotations;

namespace testeCRMEDU.Models.Dtos
{
    public class LeadDto
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string CPF { get; set; }
    }
}
