namespace CrmTest.DTO{
    public class ProcessoSeletivoDTO(){
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required DateOnly Dt_inicio { get; set; }
        public required DateOnly Dt_fim { get; set; }
    }
}