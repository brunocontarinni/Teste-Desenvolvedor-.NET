using VestibularApi.Domain.Entities;

namespace VestibularApi.API.Responses
{
    public class OfertaResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int VagasDisponiveis { get; set; }

        public OfertaResponse(Guid id, string nome, string descricao, DateTime dataInicio, DateTime dataFim, int vagasDisponiveis)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            DataInicio = dataInicio;
            DataFim = dataFim;
            VagasDisponiveis = vagasDisponiveis;
        }

        public static OfertaResponse ConverterEntity(OfertaEntities oferta)
        {
            return new OfertaResponse(
                oferta.Id,
                oferta.Nome,
                oferta.Descricao,
                oferta.DataInicio,
                oferta.DataFim,
                oferta.VagasDisponiveis
            );
        }
    }
}
