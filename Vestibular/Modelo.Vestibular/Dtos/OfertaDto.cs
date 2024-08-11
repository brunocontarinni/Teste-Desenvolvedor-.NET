namespace Modelo.Vestibular.Dtos
{
    public class OfertaDto
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public int? NumVagas { get; set; }
        public int? IdIncricao { get; set; }
        public ICollection<InscricaoDto>? Inscricoes { get; set; }
    }
}
