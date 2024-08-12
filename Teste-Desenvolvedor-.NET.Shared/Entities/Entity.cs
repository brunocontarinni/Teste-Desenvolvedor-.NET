namespace Teste_Desenvolvedor_.NET.Shared.Entities
{
    public abstract class Entity
    {

        public Entity()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
            Deleted = false;
        }

        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? DeletedDate { get; private set; }
        public DateTime UpdatedDate { get; private set; }
        public bool Deleted { get; private set; }

        public void Updated()
        {
            UpdatedDate = DateTime.Now;
        }

        public void Delete()
        {
            Deleted = true;
            DeletedDate = DateTime.Now;
            UpdatedDate = DateTime.Now;
        }
    }
}
