using System.ComponentModel.DataAnnotations.Schema;
using Teste_Desenvolvedor_.NET.Shared.Entities;

namespace Teste_Desenvolvedor_.NET.Domain.Entities
{
    public class ProcessoSeletivo : Entity
    {
        public ProcessoSeletivo(string nome, DateOnly dataInicio, DateOnly dataTermino)
        {
            Nome = nome;
            DataInicio = dataInicio;
            DataTermino = dataTermino;

            IsValid();
        }

        public string Nome { get; private set; }
        public DateOnly DataInicio { get; private set; }
        public DateOnly DataTermino { get; private set; }

        [NotMapped]
        public List<string> Notificacao { get; private set; } = new List<string>();

        public void Atualizar(string nome, DateOnly dataInicio, DateOnly dataTermino)
        {
            Nome = nome;
            DataInicio = dataInicio;
            DataTermino = dataTermino;
            Updated();
            IsValid();
        }

        public void IsValid()
        {
            if(Nome.Length < 3)
                Notificacao.Add("Nome do processo seletivo deve ter no mínimo 3 caracteres");
            if(DataInicio > DataTermino)
                Notificacao.Add("Data de início deve ser menor que a data de término");
            
        }
    }
}
