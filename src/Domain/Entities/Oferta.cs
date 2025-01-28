
namespace Domain.Entities
{
    public class Oferta
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int VagasDisponiveis { get; set; }
    }
}