using System.ComponentModel.DataAnnotations;

namespace VestibularApi.Models
{
    /// <summary>
    /// Representa um curso disponível para inscrição no processo seletivo.
    /// </summary>
    public class Curso
    {
        /// <summary>
        /// Identificador único do curso.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Nome do curso.
        /// </summary>
        [Required(ErrorMessage = "O nome do curso é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome do curso não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; }

        /// <summary>
        /// Descrição do curso, fornecendo detalhes adicionais.
        /// </summary>
        [StringLength(500, ErrorMessage = "A descrição não pode ter mais de 500 caracteres.")]
        public string Descricao { get; set; }

        /// <summary>
        /// Número de vagas disponíveis para o curso.
        /// </summary>
        [Required(ErrorMessage = "O número de vagas disponíveis é obrigatório.")]
        [Range(0, int.MaxValue, ErrorMessage = "O número de vagas deve ser um valor positivo.")]
        public int VagasDisponiveis { get; set; }
    }
}
