using System.ComponentModel.DataAnnotations;

namespace Modelo.Vestibular.ModelView
{
    public class InscricaoModelView
    {
        [Required]
        public int NumInscricao { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Required]
        public bool Status { get; set; }

        [Required]
        public int IdCadidatos { get; set; }

        [Required]
        public int IdProcessoSeletivo { get; set; }

        [Required]
        public int IdOferta { get; set; }
    }
}
