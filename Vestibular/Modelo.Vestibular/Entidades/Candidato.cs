using System.ComponentModel.DataAnnotations;

namespace Modelo.Vestibular.Entidades
{
    public class Candidato
    {
        [Key]
        public int Id { get; set; }
        
        [Length(1, 50)]
        public string Nome { get; set; }
        
        [Length(1, 100)]
        public string Email { get; set; }

        [Length(8, 12)]
        public string Telefone { get; set; }

        [Length(11, 11)]
        public string CPF { get; set; }

        public ICollection<Inscricao> Incricoes { get; set; }

        public int IdIncricao { get; set; }
    }
}
