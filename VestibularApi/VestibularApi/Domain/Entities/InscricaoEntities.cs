using System.ComponentModel.DataAnnotations;

namespace VestibularApi.Domain.Entities
{
    public class InscricaoEntities
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

        public virtual CandidatoEntities Candidato { get; private set; }
        public virtual OfertaEntities Oferta { get; private set; }

        public InscricaoEntities()
        {
        }

        public InscricaoEntities(Guid candidatoId, Guid ofertaId, DateTime dataInscricao, StatusInscricao status)
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
