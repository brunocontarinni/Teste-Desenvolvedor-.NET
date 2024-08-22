using VestibularApi.Domain.Entities;

namespace VestibularApi.API.Responses
{
    public class CandidatoResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public DateTime DataCriacao { get; set; }

        public CandidatoResponse(Guid id, string nome, string cpf, DateTime dataCriacao)
        {
            Id = id;
            Nome = nome;
            CPF = cpf;
            DataCriacao = dataCriacao;
        }

        public static CandidatoResponse ConverterEntity(CandidatoEntities candidato)
        {
            return new CandidatoResponse(
                candidato.Id,
                candidato.Nome,
                candidato.CPF,
                DateTime.UtcNow
            );
        }
    }
}
