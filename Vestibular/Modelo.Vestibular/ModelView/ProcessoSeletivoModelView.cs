using System.ComponentModel.DataAnnotations;

namespace Modelo.Vestibular.ModelView
{
    public class ProcessoSeletivoModelView
    {
        [Required]
        [Length(1, 50)]
        public string Nome { get; set; }

        [Required]
        public DateTime DataDeInicil { get; set; }

        [Required]
        public DateTime DataDeTermio { get; set; }
    }
}
