using System.ComponentModel.DataAnnotations;

namespace Modelo.Vestibular.Entidades
{
    public class ProcessoSeletivo
    {
        [Key]
        public int Id { get; set; }

        [Length(1, 50)]
        public string Nome { get; set; }

        public DateTime DataDeInicil { get; set; }

        public DateTime DataDeTermio { get;set; }

        public ICollection<Inscricao> Incricoes { get; set; }

        public int IdIncricao { get; set; }
    }
}
