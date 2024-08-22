using System.ComponentModel.DataAnnotations;

namespace VestibularApi.Domain.Entities
{
    public class ProcessoSeletivoEntities
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DataInicio { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [CustomValidation(typeof(ProcessoSeletivoEntities), nameof(ValidarDatas))]
        public DateTime DataTermino { get; set; }

        public ICollection<InscricaoEntities> Inscricoes { get; set; } = new List<InscricaoEntities>();

        public ProcessoSeletivoEntities() { }

        public ProcessoSeletivoEntities(string nome, DateTime dataInicio, DateTime dataTermino)
        {
            Nome = nome;
            DataInicio = dataInicio;
            DataTermino = dataTermino;
        }

        public void Atualizar(string nome, DateTime dataInicio, DateTime  dataTermino)
        {
            Nome = nome;
            DataInicio = dataInicio;
            DataTermino = dataTermino;
        }

        public static ValidationResult ValidarDatas(DateTime dataTermino, ValidationContext context)
        {
            var instance = (ProcessoSeletivoEntities)context.ObjectInstance;

            if (dataTermino < instance.DataInicio)
            {
                return new ValidationResult("A data de término não pode ser anterior à data de início.");
            }

            return ValidationResult.Success;
        }
    }
}
