using System;

namespace Domain.Entities
{
    public class InscricaoDB
    {
        public int Id { get; set; }
        public int NumeroInscricao { get; set; }
        public DateTime Data { get; set; }
        public char Status { get; set; }
        public int CandidatoId { get; set; }
        public int ProcessoSeletivoId { get; set; }
        public int OfertaId { get; set; }
    }
}