namespace Modelo.Vestibular.Dtos
{
    public class ProcessoSeletivoDto
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataDeInicil { get; set; }
        public DateTime? DataDeTermio { get; set; }
        public int? IdIncricao { get; set; }
        public ICollection<InscricaoDto>? Inscricoes { get; set; }
    }
}
