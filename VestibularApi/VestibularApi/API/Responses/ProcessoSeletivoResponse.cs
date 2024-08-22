using VestibularApi.Domain.Entities;

namespace VestibularApi.API.Responses
{
    public class ProcessoSeletivoResponse
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }

        public ProcessoSeletivoResponse(Guid id, string nome, DateTime dataInicio, DateTime dataTermino)
        {
            Id = id;
            Nome = nome;
            DataInicio = dataInicio;
            DataTermino = dataTermino;
        }

        public static ProcessoSeletivoResponse ConverterEntity(ProcessoSeletivoEntities processoSeletivo)
        {
            return new ProcessoSeletivoResponse(
                processoSeletivo.Id,
                processoSeletivo.Nome,
                processoSeletivo.DataInicio,
                processoSeletivo.DataTermino
            );
        }
    }
}
