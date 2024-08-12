using System.ComponentModel.DataAnnotations;

namespace CrmTest.Models{
    public class ProcessoSeletivo{
        [Key]
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required DateOnly Dt_inicio { get; set; }
        public required DateOnly Dt_fim { get; set; }
    }
}
