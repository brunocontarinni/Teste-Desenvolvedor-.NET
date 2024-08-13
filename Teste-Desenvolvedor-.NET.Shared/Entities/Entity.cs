namespace Teste_Desenvolvedor_.NET.Shared.Entities
{
    public abstract class Entity
    {
        // Construtor da Entidade Base
        public Entity()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            Deleted = false;
        }
        // ID de todas as Entidades
        public Guid Id { get; private set; }
        // Data de Criação da Entidade
        public DateTime CreatedDate { get; private set; }
        //Data de Deleção da Entidade
        public DateTime? DeletedDate { get; private set; }
        // Data de Atualização da Entidade
        public DateTime UpdatedDate { get; private set; }
        // Fleg de Deleção da Entidade
        public bool Deleted { get; private set; }

        // Atualiza a data de Atualização
        public void Updated()
        {
            UpdatedDate = DateTime.Now;
        }

        // Atualiza a data de Deleção, a fleg e a data de Atualiação
        public void Delete()
        {
            Deleted = true;
            DeletedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }
    }
}
