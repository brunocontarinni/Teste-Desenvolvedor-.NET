
using System.ComponentModel.DataAnnotations.Schema;
using Teste_Desenvolvedor_.NET.Shared.Entities;

namespace Teste_Desenvolvedor_.NET.Domain.Entities
{
    public class Inscricao : Entity
    {
        public Inscricao(string nome, int status, Guid idOferta, Oferta oferta, Guid idLead, Lead lead, Guid idProcessoSeletivo, ProcessoSeletivo processoSeletivo)
        {
            Nome = nome;
            Data = DateTime.Now;
            Status = status;
            IdOferta = idOferta;
            Oferta = oferta;
            IdLead = idLead;
            Lead = lead;
            IdProcessoSeletivo = idProcessoSeletivo;
            ProcessoSeletivo = processoSeletivo;
        }

        private Inscricao() { }

        public string Nome { get; private set; }
        public DateTime Data { get; private set; }
        public int Status { get; private set; }
        public Guid IdOferta { get; private set; }
        public Oferta? Oferta { get;  set; }
        public Guid IdLead { get; private set; }
        public Lead? Lead { get;  set; }
        public Guid IdProcessoSeletivo { get; private set; }
        public ProcessoSeletivo? ProcessoSeletivo { get;  set; }

        [NotMapped]
        public List<string> Notificacao { get; private set; } = new List<string>();

        public void Atualizar(string nome,int status, Guid idOferta, Guid idLead, Guid idProcessoSeletivo )
        {
            Nome = nome;
            Status = status;
            IdOferta = idOferta;
            IdLead = idLead;
            IdProcessoSeletivo = idProcessoSeletivo;
            Updated();
            IsValid();
        }

        public void IsValid()
        {
           if(Nome.Length<3)
            {
                Notificacao.Add("Nome deve conter no mínimo 3 caracteres");
            }
            if(Status<0 )
            {
                Notificacao.Add("Status deve ser maior que 0");
            }
            if(IdOferta == Guid.Empty)
            {
                Notificacao.Add("Id da oferta não pode ser vazio");
            }
            if(IdLead == Guid.Empty)
            {
                Notificacao.Add("Id do lead não pode ser vazio");
            }
            if(IdProcessoSeletivo == Guid.Empty)
            {
                Notificacao.Add("Id do processo seletivo não pode ser vazio");
            }
            if(Lead == null)
            {
                Notificacao.Add("Lead não encontrado");
            }
            if(Oferta == null)
            {
                Notificacao.Add("Oferta não encontrada");
            }
            if(ProcessoSeletivo == null)
            {
                Notificacao.Add("Processo seletivo não encontrado");
            }
        }

        public void AddNotification(string key, string message)
        {
            Notificacao.Add(key + " - " + message);
        }
    }
}
