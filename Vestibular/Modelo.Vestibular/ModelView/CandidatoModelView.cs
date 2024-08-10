using System.ComponentModel.DataAnnotations;

namespace Modelo.Vestibular.ModelView
{
    public class CandidatoModelView
    {
        [Required]
        [Length(1, 50)]
        public string Nome { get; set; }

        [Required]
        [Length(1, 100)]
        public string Email { get; set; }

        [Required]
        [Length(8, 12)]
        public string Telefone { get; set; }

        [Required]
        [Length(11, 11)]
        public string CPF { get; set; }
    }
}
