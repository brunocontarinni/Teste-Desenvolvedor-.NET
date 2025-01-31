using System.Text.Json.Serialization;

namespace VestibularApi.Domain.Entities
{
    public class Lead
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;

        [JsonIgnore]
        public ICollection<Inscricao> Inscricoes { get; set; } = new List<Inscricao>();
    }
}
