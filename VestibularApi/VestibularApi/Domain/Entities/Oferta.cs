namespace VestibularApi.Domain.Entities
{
    public class Oferta
    {
        public Guid Id { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataFim { get; private set; }

    }
}
