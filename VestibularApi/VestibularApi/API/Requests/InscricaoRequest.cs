using VestibularApi.Domain.Entities;

namespace VestibularApi.API.Requests
{
    public class InscricaoRequest
    {
        public string NumeroInscricao { get; set; }
        public Guid ProcessoSeletivoId { get; set; }
        public Guid CandidatoId { get; set; }
        public Guid OfertaId { get; set; }
        public DateTime DataInscricao { get; set; }
        public StatusInscricao Status { get; set; }
    }
}
