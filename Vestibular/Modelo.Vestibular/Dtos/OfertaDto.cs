namespace Modelo.Vestibular.Dtos
{
    public record OfertaDto
    (
        int Id,
        string Nome,
        string? Descricao,
        int NumVagas,
        int IdIncricao,
        ICollection<InscricaoDto> Inscricoes
    );
}
