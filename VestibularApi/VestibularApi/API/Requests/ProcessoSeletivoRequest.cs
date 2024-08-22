using System.ComponentModel.DataAnnotations;

namespace VestibularApi.API.Requests
{
    public class ProcessoSeletivoRequest
    {
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A data de início é obrigatória")]
        [DataType(DataType.Date, ErrorMessage = "Formato de data inválido")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "A data de término é obrigatória")]
        [DataType(DataType.Date, ErrorMessage = "Formato de data inválido")]
        [CustomValidation(typeof(ProcessoSeletivoRequest), nameof(ValidarDatas))]
        public DateTime DataTermino { get; set; }

        public static ValidationResult ValidarDatas(DateTime dataTermino, ValidationContext context)
        {
            var instance = (ProcessoSeletivoRequest)context.ObjectInstance;

            if (dataTermino < instance.DataInicio)
            {
                return new ValidationResult("A data de término não pode ser anterior à data de início.");
            }

            return ValidationResult.Success;
        }
    }
}
