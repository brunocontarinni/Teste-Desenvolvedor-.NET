using System;

namespace Domain.Entities
{
    public class Inscricao
    {
        public int Id { get; set; }
        public int NumeroInscricao { get; set; }
        public DateTime Data { get; set; }
        public char Status { get; set; }
        public Candidato Candidato { get; set; }
        public ProcessoSeletivo ProcessoSeletivo { get; set; }
        public Oferta Oferta { get; set; }
    }
}