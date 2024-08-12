namespace CrmTest.DTO{
    public class LeadDTO(){
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public string? Telefone { get; set; }
        public required string Cpf { get; set; }
    }
}