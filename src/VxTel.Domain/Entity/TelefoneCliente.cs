namespace VxTel.Domain.Entity
{
    public partial class TelefoneCliente : BaseEntity
    {
        public int IdCliente { get; private set; }

        public string Ddd { get; private set; }

        public long Telefone { get; private set; }

        public virtual Cliente Cliente { get; private set; }

        public TelefoneCliente(int id, int idCliente, string ddd, long telefone)
            : base(id)
        {
            IdCliente = idCliente;
            Ddd = ddd;
            Telefone = telefone;
        }
    }
}
