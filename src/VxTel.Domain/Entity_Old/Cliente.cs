namespace VxTel.Domain.Entity
{
    public sealed class Cliente
    {
        public int Id { get; private set; }

        public string Nome { get; private set; }

        public string Documento { get; private set; }

        public Cliente(int id, string nome, string documento)
        {
            Id = id;
            Nome = nome;
            Documento = documento;
        }
    }
}
