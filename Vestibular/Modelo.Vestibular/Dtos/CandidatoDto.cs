namespace Modelo.Vestibular.Dtos
{
    public record CandidatoDto
    (
        int Id,
        string Nome,
        string Email,
        string Telefone,
        string CPF,
        int IdIncricao,
        ICollection<InscricaoDto> Inscricoes
    );
}
