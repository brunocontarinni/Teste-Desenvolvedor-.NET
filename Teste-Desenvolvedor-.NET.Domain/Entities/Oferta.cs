
using System.ComponentModel.DataAnnotations.Schema;
using Teste_Desenvolvedor_.NET.Shared.Entities;
namespace Teste_Desenvolvedor_.NET.Domain.Entities
{
     public class Oferta: Entity
    {
        //Construtor da Classe
        public Oferta(string nome, string descricao, int vagasDisponiveis)
        {
            Nome = nome;
            Descricao = descricao;
            VagasDisponiveis = vagasDisponiveis;
            IsValid();
        }
        // Construtor para a Migração
        private Oferta() { }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public int VagasDisponiveis { get; private set; }

        // Lista de Notificações para armazenar erros na Entidade
        [NotMapped]
        public List<string> Notificacao { get; private set; } = new List<string>();

        // Função para Atualizar as prorpiedades da Classe
        public void Atualizar(string nome, string descricao, int vagasDisponiveis)
        {
            Nome = nome;
            Descricao = descricao;
            VagasDisponiveis = vagasDisponiveis;
            IsValid();
            Updated();
            
        }

        //Verifica se a entidade é valida, caso nao adiciona a respectiva notificação a lista
        public void IsValid()
        {
            if(Nome.Length < 3)
                Notificacao.Add("Nome da oferta deve ter no mínimo 3 caracteres");
            if(Descricao.Length < 3)
                Notificacao.Add("Descrição da oferta deve ter no mínimo 3 caracteres");
            if(VagasDisponiveis <= 0)
                Notificacao.Add("Vagas disponíveis devem ser maiors ou iguais a 0");
        }
        // Função para notificação customizada
        public void AddNotification(string key, string message)
        {
            Notificacao.Add(key + " - " + message);
        }


    }
}
