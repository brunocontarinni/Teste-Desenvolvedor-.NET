using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Teste.Models
{
    [Table("ProcessoSeletivo")]
    public class ProcessoSeletivo
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
        
        [Column("nome")]
        public required string Nome { get; set; }
        
        [Column("datainicio")]
        [DisplayName("Data de Início")]
        public DateTime DataInicio { get; set; }

        [Column("datatermino")]
        [DisplayName("Data de Término")]
        public DateTime DataTermino { get; set; }        
    }
}
