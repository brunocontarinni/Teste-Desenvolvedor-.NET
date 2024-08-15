using Microsoft.AspNetCore.SignalR.Protocol;

namespace VestibularAPI.Models
{
    public class Inscricao
    {
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public string Status { get; set; }
        public int IDProcessoSeletivo { get; set; }
        public int IDLead { get; set; }
        public Lead Lead { get; set; } // Relacionamento com Lead

        public int IDOferta { get; set; }
    }
}