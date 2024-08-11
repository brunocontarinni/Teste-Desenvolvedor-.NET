namespace appMain.Models
{
    public class OfertaModel
    {
        public string nome { get; set; }
        public string Descricao { get; set; }
        public int vagas_disponiveis { get; set; }
    }

    public class CandidatoModel
    {
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string cpf { get; set; }
    }
    public class ProcessoModel
    {
        public string nome { get; set; }
        public string data_inicio { get; set; }
        public string data_fim { get; set; }
    }

    public class InscricaoModel
    {
        public int id_lead { get; set; }
        public int id_processo_seletivo { get; set; }
        public int id_oferta { get; set; }
        public string status { get; set; }
    }
}
