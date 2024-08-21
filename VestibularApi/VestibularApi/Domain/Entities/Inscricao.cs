namespace VestibularApi.Domain.Entities
{
    public class Inscricao
    {
        public Guid Id { get; private set; }
        public Guid CandidatoId { get; private set; }
        public Guid OfertaId { get; private set; }
        public DateTime DataInscricao { get; private set; }

    }
}
