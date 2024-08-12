using System.ComponentModel.DataAnnotations;

namespace CrmTest.Models{
    public class Erro{
        public string? Title { get; set; }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
    }
}