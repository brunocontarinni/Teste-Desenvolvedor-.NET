using System;
using System.ComponentModel.DataAnnotations;

namespace VestibularApi.Domain.Entities
{
    public class Inscricao
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        public Guid CandidatoId { get; private set; }

        [Required]
        public Guid OfertaId { get; private set; }

        [Required]
        public DateTime DataInscricao { get; private set; }

        [Required]
        public StatusInscricao Status { get; private set; }

        public virtual Candidato Candidato { get; private set; }
        public virtual Oferta Oferta { get; private set; }

        public Inscricao()
        {
        }

        public Inscricao(Guid candidatoId, Guid ofertaId, DateTime dataInscricao, StatusInscricao status)
        {
            Id = Guid.NewGuid();
            CandidatoId = candidatoId;
            OfertaId = ofertaId;
            DataInscricao = dataInscricao;
            Status = status;
        }

        public void AtualizarStatus(StatusInscricao novoStatus)
        {
            Status = novoStatus;
        }
    }

    public enum StatusInscricao
    {
        Pendente,
        Confirmada,
        Cancelada
    }
}
