using System.ComponentModel.DataAnnotations.Schema;
using Teste_Desenvolvedor_.NET.Shared.Entities;

namespace Teste_Desenvolvedor_.NET.Domain.Entities
{
    public class ProcessoSeletivo : Entity
    {
        //Construtor da Classe
        public ProcessoSeletivo(string nome, DateTime dataInicio, DateTime dataTermino)
        {
            Nome = nome;
            //Conversão de Datetime para DateOnly
            DataInicio = DateOnly.FromDateTime( dataInicio);
            DataTermino = DateOnly.FromDateTime( dataTermino);

            IsValid();
        }

        private ProcessoSeletivo() { }

        public string Nome { get; private set; }
        public DateOnly DataInicio { get; private set; }
        public DateOnly DataTermino { get; private set; }

        // Lista de Notificações para armazenar erros na Entidade
        [NotMapped]
        public List<string> Notificacao { get; private set; } = new List<string>();

        //Função que atualiza as propriedades da Classe
        public void Atualizar(string nome, DateOnly dataInicio, DateOnly dataTermino)
        {
            Nome = nome;
            DataInicio = dataInicio;
            DataTermino = dataTermino;
            Updated();
            IsValid();
        }
        // Verifica se a Entidade é valida, caso nao adiciona arespectiva notificação a lista
        public void IsValid()
        {
            if(Nome.Length < 3)
                Notificacao.Add("Nome do processo seletivo deve ter no mínimo 3 caracteres");
            if(DataInicio > DataTermino)
                Notificacao.Add("Data de início deve ser menor que a data de término");
            
        }
        // Função para criar notificações customizadas
        public void AddNotification(string key, string message)
        {
            Notificacao.Add(key + " - " + message);
        }
    }
}
