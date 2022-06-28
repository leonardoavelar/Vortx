namespace VxTel.Domain.Entity
{
    public partial class TelefoneCliente
    {
        public int Id { get; private set; }

        public int IdCliente { get; private set; }

        public string Ddd { get; private set; }

        public long Telefone { get; private set; }

        public virtual Cliente Cliente { get; private set; }

        public TelefoneCliente(int id, int idCliente, string ddd, long telefone)
        {
            Id = id;
            IdCliente = idCliente;
            Ddd = ddd;
            Telefone = telefone;
        }
    }
}
