using System.Text.Json.Serialization;

namespace VestibularApi.Domain.Entities
{
    public class Oferta
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public int VagasDisponiveis { get; set; }

        [JsonIgnore]
        public ICollection<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();
    }
}
