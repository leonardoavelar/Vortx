namespace VxTel.Domain.Entity
{
    public sealed class Tarifa
    {
        public int Id { get; private set; }

        public string DddOrigem { get; private set; }

        public string DddDestino { get; private set; }

        public Tarifa(int id, string dddOrigem, string dddDestino)
        {
            Id = id;
            DddOrigem = dddOrigem;
            DddDestino = dddDestino;
        }
    }
}
