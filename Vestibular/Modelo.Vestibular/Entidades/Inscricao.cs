using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Modelo.Vestibular.Entidades
{
    public class Inscricao
    {
        [Key]
        public int Id { get; set; }

        public int NumInscricao { get; set; }

        public DateTime Data { get; set; }

        public bool Status { get; set; }

        [ForeignKey(nameof(Entidades.Candidato.Id))]
        public int IdCadidatos { get; set; }

        public Candidato Candidato { get; set; }

        [ForeignKey(nameof(Entidades.ProcessoSeletivo.Id))]
        public int IdProcessoSeletivo { get; set; }

        public ProcessoSeletivo ProcessoSeletivo { get; set; }

        [ForeignKey(nameof(Entidades.Oferta.Id))]
        public int IdOferta { get; set; }

        public Oferta Oferta { get; set; }
    }
}
