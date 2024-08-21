namespace VestibularApi.API.Responses
{
    public class CandidatoResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataCriacao { get; set; }
    }
}
