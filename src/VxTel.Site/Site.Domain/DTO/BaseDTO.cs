namespace VxTel.Site.Domain.DTO
{
    public abstract class BaseDTO
    {
        public int Id { get; set; }

        public BaseDTO() {}

        public BaseDTO(int id) { Id = id; }

        public abstract override bool Equals(object obj);

        public abstract override int GetHashCode();
    }
}
