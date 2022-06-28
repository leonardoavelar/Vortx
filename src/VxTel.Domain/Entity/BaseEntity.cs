namespace VxTel.Domain.Entity
{
    public class BaseEntity
    {
        public int Id { get; private set; }

        public BaseEntity(int id)
        {
            Id = id;
        }

    }
}
