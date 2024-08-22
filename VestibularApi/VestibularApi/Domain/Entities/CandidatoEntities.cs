using System;
using System.ComponentModel.DataAnnotations;

namespace VestibularApi.Domain.Entities
{
    public class CandidatoEntities
    {
        [Key]
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "O CPF é obrigatório")]
        [StringLength(11, ErrorMessage = "O CPF deve ter exatamente 11 dígitos")]
        public string CPF { get; private set; }

        [Required]
        public DateTime DataCriacao { get; private set; }

        protected CandidatoEntities()
        {
            DataCriacao = DateTime.Now;
        }

        public CandidatoEntities(string nome, string cpf)
        {
            if (!ValidarCPF(cpf))
                throw new ArgumentException("CPF inválido");

            Id = Guid.NewGuid();
            Nome = nome ?? throw new ArgumentNullException(nameof(nome));
            CPF = cpf;
            DataCriacao = DateTime.Now;
        }

        public void AlterarNome(string novoNome)
        {
            if (string.IsNullOrWhiteSpace(novoNome) || novoNome.Length > 100)
                throw new ArgumentException("Nome inválido");

            Nome = novoNome;
        }

        public void AlterarCPF(string novoCPF)
        {
            if (!ValidarCPF(novoCPF))
                throw new ArgumentException("CPF inválido");

            CPF = novoCPF;
        }

        private bool ValidarCPF(string cpf)
        {
            if (cpf.Length != 11 || !long.TryParse(cpf, out _))
                return false;

            return true;
        }
    }
}
