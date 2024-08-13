using System.ComponentModel.DataAnnotations;

namespace VestibularApi.Models
{
    /// <summary>
    /// Representa uma inscrição feita por um candidato em um curso dentro de um processo seletivo.
    /// </summary>
    public class Inscricao
    {
        /// <summary>
        /// Identificador único da inscrição.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Número da inscrição, usado para identificação específica no processo seletivo.
        /// </summary>
        [Required(ErrorMessage = "O número de inscrição é obrigatório.")]
        public int NumeroInscricao { get; set; }

        /// <summary>
        /// Data em que a inscrição foi realizada.
        /// </summary>
        [Required(ErrorMessage = "A data de inscrição é obrigatória.")]
        public DateTime DataInscricao { get; set; }

        /// <summary>
        /// Status atual da inscrição (Ativo, Cancelado, Pendente).
        /// </summary>
        [Required(ErrorMessage = "O status da inscrição é obrigatório.")]
        public StatusInscricao Status { get; set; }

        /// <summary>
        /// Identificador do candidato que realizou a inscrição.
        /// </summary>
        [Required(ErrorMessage = "O ID do candidato é obrigatório.")]
        public int CandidatoId { get; set; }

        /// <summary>
        /// Referência ao candidato que realizou a inscrição.
        /// </summary>
        public Candidato Candidato { get; set; }

        /// <summary>
        /// Identificador do processo seletivo ao qual a inscrição pertence.
        /// </summary>
        [Required(ErrorMessage = "O ID do processo seletivo é obrigatório.")]
        public int ProcessoSeletivoId { get; set; }

        /// <summary>
        /// Referência ao processo seletivo ao qual a inscrição pertence.
        /// </summary>
        public ProcessoSeletivo ProcessoSeletivo { get; set; }

        /// <summary>
        /// Identificador do curso ao qual a inscrição está vinculada.
        /// </summary>
        [Required(ErrorMessage = "O ID do curso é obrigatório.")]
        public int CursoId { get; set; }

        /// <summary>
        /// Referência ao curso ao qual a inscrição está vinculada.
        /// </summary>
        public Curso Curso { get; set; }
    }

    /// <summary>
    /// Enumeração que define os possíveis status de uma inscrição.
    /// </summary>
    public enum StatusInscricao
    {
        /// <summary>
        /// Indica que a inscrição está ativa.
        /// </summary>
        Ativo,

        /// <summary>
        /// Indica que a inscrição foi cancelada.
        /// </summary>
        Cancelado,

        /// <summary>
        /// Indica que a inscrição está pendente e requer ação.
        /// </summary>
        Pendente
    }
}
