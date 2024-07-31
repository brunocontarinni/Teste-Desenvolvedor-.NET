using System.ComponentModel.DataAnnotations;

namespace vestibular_info.Models
{
    public class Lead
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }

        [Required]
        public string CPF { get; set; }
    }
}
