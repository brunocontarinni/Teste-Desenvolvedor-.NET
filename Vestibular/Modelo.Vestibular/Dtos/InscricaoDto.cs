namespace Modelo.Vestibular.Dtos
{
    public class InscricaoDto
    {
        public int? Id { get; set; }
        public int? NumInscricao { get; set; }
        public DateTime? Data {  get; set; }   
        public bool? Status { get; set; }
        public int? IdCadidatos { get; set; }
        public int? IdProcessoSeletivo { get; set; }
        public int? IdOferta { get; set; }
    }
}
