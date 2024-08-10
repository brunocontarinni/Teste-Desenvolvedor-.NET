namespace Modelo.Vestibular.Dtos
{
    public record ProcessoSeletivoDto
    (
        int Id,
        string Nome,
        DateTime DataDeInicil,
        DateTime DataDeTermio,
        int IdIncricao,
        ICollection<InscricaoDto> Inscricoes
    );
}
