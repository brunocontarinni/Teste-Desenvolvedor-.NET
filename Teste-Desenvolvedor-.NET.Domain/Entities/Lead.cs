using System.ComponentModel.DataAnnotations.Schema;
using Teste_Desenvolvedor_.NET.Shared.Entities;

namespace Teste_Desenvolvedor_.NET.Domain.Entities
{
    public class Lead: Entity
    {
        public Lead(string nome, string email, string telefone, string cpf)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            CPF = cpf;
            IsValid();
        }

        private Lead() { }

        public string Nome { get;private set; } 
        public string Email { get;private set; }
        public string Telefone { get;private set; }
        public string CPF { get;private set; }



        [NotMapped]
        public List<string> Notificacao { get; private set; } = new List<string>();

        public void Atualizar(string nome, string email, string telefone, string cpf)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            CPF = cpf;
            IsValid();
            Updated();
        }

        public void IsValid()
        {
            if(Nome.Length < 3)
                Notificacao.Add("Nome do lead deve ter no mínimo 3 caracteres");
            if(Email.Length < 3)
                Notificacao.Add("Email do lead deve ter no mínimo 3 caracteres");
            if(Telefone.Length < 3)
                Notificacao.Add("Telefone do lead deve ter no mínimo 3 caracteres");
            if(CPF.Length < 3)
                Notificacao.Add("CPF do lead deve ter no mínimo 3 caracteres");
            
        }
        public void AddNotificacao(string key, string message)
        {
            Notificacao.Add(key + " - " + message);
        }
    }
}
