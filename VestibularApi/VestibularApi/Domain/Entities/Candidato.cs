namespace VestibularApi.Domain.Entities
{
    public class Candidato
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }

        public Candidato(string nome, string cpf)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            CPF = cpf;
        }

        public void AlterarNome(string novoNome)
        {
            Nome = novoNome;
        }

        public void AlterarCPF(string novoCPF)
        {
            CPF = novoCPF;
        }

    }
}
