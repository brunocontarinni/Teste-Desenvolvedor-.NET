namespace vestibular_info.Models
{
    public class ProcessoSeletivo
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
    }
}
