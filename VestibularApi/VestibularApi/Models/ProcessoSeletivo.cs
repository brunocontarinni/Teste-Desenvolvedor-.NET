using System.ComponentModel.DataAnnotations;

namespace VestibularApi.Models
{
    /// <summary>
    /// Representa um processo seletivo em que os candidatos podem se inscrever.
    /// </summary>
    public class ProcessoSeletivo
    {
        /// <summary>
        /// Identificador único do processo seletivo.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do processo seletivo.
        /// </summary>
        [Required(ErrorMessage = "O nome do processo seletivo é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; }

        /// <summary>
        /// Data de início do processo seletivo.
        /// </summary>
        [Required(ErrorMessage = "A data de início é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "Formato de data inválido.")]
        public DateTime DataInicio { get; set; }

        /// <summary>
        /// Data de término do processo seletivo.
        /// </summary>
        [Required(ErrorMessage = "A data de término é obrigatória.")]
        [DataType(DataType.Date, ErrorMessage = "Formato de data inválido.")]
        [DateGreaterThan("DataInicio", ErrorMessage = "A data de término deve ser posterior à data de início.")]
        public DateTime DataTermino { get; set; }
    }

    /// <summary>
    /// Validação personalizada para garantir que uma data é maior que outra.
    /// </summary>
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="DateGreaterThanAttribute"/>.
        /// </summary>
        /// <param name="comparisonProperty">Nome da propriedade a ser comparada.</param>
        public DateGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        /// <summary>
        /// Verifica se o valor atual é maior que o valor da propriedade de comparação.
        /// </summary>
        /// <param name="value">Valor atual a ser validado.</param>
        /// <param name="validationContext">Contexto de validação.</param>
        /// <returns>Resultado da validação.</returns>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentValue = (DateTime)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);

            if (property == null)
                throw new ArgumentException("Esta propriedade não existe.");

            var comparisonValue = (DateTime)property.GetValue(validationContext.ObjectInstance);

            if (currentValue <= comparisonValue)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
