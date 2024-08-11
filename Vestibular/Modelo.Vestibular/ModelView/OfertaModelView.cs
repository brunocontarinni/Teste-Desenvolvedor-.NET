using System.ComponentModel.DataAnnotations;

namespace Modelo.Vestibular.ModelView
{
    public class OfertaModelView
    {
        [Required]
        [Length(1, 50)]
        public string Nome { get; set; }

        [Length(0, 100)]
        public string? Descricao { get; set; }

        [Required]
        public int NumVagas { get; set; }
    }
}
