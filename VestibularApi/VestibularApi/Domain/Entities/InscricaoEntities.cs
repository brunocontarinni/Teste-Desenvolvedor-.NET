using System.ComponentModel.DataAnnotations;

namespace VestibularApi.Domain.Entities
{
    public class InscricaoEntities
    {
        [Key]
        public Guid Id { get; private set; }

        [Required]
        [MaxLength(20)]
        public string NumeroInscricao { get; private set; }

        [Required]
        public DateTime Data { get; private set; }

        [Required]
        public StatusInscricao Status { get; private set; }

        [Required]
        public Guid ProcessoSeletivoId { get; private set; }

        [Required]
        public Guid OfertaId { get; private set; }

        [Required]
        public Guid CandidatoId { get; private set; }

        public virtual ProcessoSeletivoEntities ProcessoSeletivo { get; private set; }
        public virtual OfertaEntities Oferta { get; private set; }
        public virtual CandidatoEntities Candidato { get; private set; }

        public InscricaoEntities()
        {
        }

        public InscricaoEntities(string numeroInscricao, Guid processoSeletivoId, Guid ofertaId, Guid candidatoId, DateTime data, StatusInscricao status)
        {
            Id = Guid.NewGuid();
            NumeroInscricao = numeroInscricao;
            ProcessoSeletivoId = processoSeletivoId;
            OfertaId = ofertaId;
            CandidatoId = candidatoId;
            Data = data;
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
