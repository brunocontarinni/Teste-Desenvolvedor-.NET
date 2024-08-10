using System.ComponentModel.DataAnnotations;

namespace Modelo.Vestibular.Entidades
{
    public class Oferta
    {
        [Key]
        public int Id { get; set; }

        [Length(1, 50)]
        public string Nome { get; set; }

        [Length(0, 100)]
        public string? Descricao { get; set; }

        public int NumVagas { get; set; }

        public ICollection<Inscricao> Incricoes { get; set; }

        public int IdIncricao { get; set; }
    }
}
