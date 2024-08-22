using System.ComponentModel.DataAnnotations;

namespace VestibularApi.Domain.Entities
{
    public class Oferta
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; private set; }

        [Required]
        [MaxLength(500)]
        public string Descricao { get; private set; }

        [Required]
        public DateTime DataInicio { get; private set; }

        [Required]
        public DateTime DataFim { get; private set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "O número de vagas disponíveis deve ser maior que zero.")]
        public int VagasDisponiveis { get; private set; }

        public Oferta()
        {
        }

        public Oferta(string nome, string descricao, DateTime dataInicio, DateTime dataFim, int vagasDisponiveis)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            Descricao = descricao;
            DataInicio = dataInicio;
            DataFim = dataFim;
            VagasDisponiveis = vagasDisponiveis;
        }

        public void AtualizarOferta(string nome, string descricao, DateTime dataInicio, DateTime dataFim, int vagasDisponiveis)
        {
            Nome = nome;
            Descricao = descricao;
            DataInicio = dataInicio;
            DataFim = dataFim;
            VagasDisponiveis = vagasDisponiveis;
        }
    }
}
