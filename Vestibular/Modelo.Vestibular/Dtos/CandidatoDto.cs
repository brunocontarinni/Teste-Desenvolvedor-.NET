namespace Modelo.Vestibular.Dtos
{
    public class CandidatoDto
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? CPF { get; set; }
        public int? IdIncricao { get; set; }
        public ICollection<InscricaoDto>? Inscricoes { get; set; }
    }
}
