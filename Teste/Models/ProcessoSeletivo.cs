using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Teste.Models
{
    public class ProcessoSeletivo
    {
        [Key]
        public int IdProcessoSeletivo { get; set; }
        public string Nome { get; set; }
        public DateTime? DataDeInicio { get; set; }
        public DateTime? DataDeTermino { get; set; }
    }
}