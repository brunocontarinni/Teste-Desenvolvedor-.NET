
using System.ComponentModel.DataAnnotations.Schema;
using Teste_Desenvolvedor_.NET.Shared.Entities;

namespace Teste_Desenvolvedor_.NET.Domain.Entities
{
    public class Inscricao : Entity
    {
        //Construtor da Classe
        public Inscricao(string nome, 
            int status, 
            Guid idOferta, 
            Oferta oferta, 
            Guid idLead, 
            Lead lead, 
            Guid idProcessoSeletivo, 
            ProcessoSeletivo processoSeletivo)
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

        //Construtir para a migração
        private Inscricao() { }
        
        //Nome da Inscrição
        public string Nome { get; private set; }
        //Data da Inscrição
        public DateTime Data { get; private set; }
        //Status da Inscrição
        public int Status { get; private set; }
        //Id da Oferta
        public Guid IdOferta { get; private set; }
        //Oferta, podendo ser nula
        public Oferta? Oferta { get;  set; }
        // Id do Lead
        public Guid IdLead { get; private set; }
        // Lead, podendo ser nulo
        public Lead? Lead { get;  set; }
        // Id do Processo Seletivo
        public Guid IdProcessoSeletivo { get; private set; }
        // Processo Seletivo, podendo ser nulo
        public ProcessoSeletivo? ProcessoSeletivo { get;  set; }

        // Lista de Notificações, verifica armazena erros da Entidade
        [NotMapped]
        public List<string> Notificacao { get; private set; } = new List<string>();

        // Atualiza as prorpiedades do Objeto
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

        // Verifica se a Entidade é valida, se nao for adiciona a respectiva notificação
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

        // Função para adicionar notificações customizadas
        public void AddNotification(string key, string message)
        {
            Notificacao.Add(key + " - " + message);
        }
    }
}
