namespace CrmTest.DTO{
    public class OfertaDTO{
        public int Id { get; set; }
        public required string Nome{ get; set; }
        public string? Descricao { get; set; }
        public int Qtd_Vagas_Disponiveis { get; set; }
    }
}