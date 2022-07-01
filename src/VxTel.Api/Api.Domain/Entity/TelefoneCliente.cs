namespace VxTel.Api.Domain.Entity
{
    public partial class TelefoneCliente : BaseEntity
    {
        public int ClienteId { get; private set; }

        public virtual Cliente Cliente { get; private set; }

        public string Ddd { get; private set; }

        public long Telefone { get; private set; }
    }
}
