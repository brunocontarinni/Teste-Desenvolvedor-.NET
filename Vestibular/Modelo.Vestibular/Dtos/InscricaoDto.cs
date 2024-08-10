namespace Modelo.Vestibular.Dtos
{
    public record InscricaoDto
    (
        int Id, 
        int NumInscricao, 
        DateTime Data, 
        bool Status, 
        int IdCadidatos,
        int IdProcessoSeletivo,
        int IdOferta
    );
}
