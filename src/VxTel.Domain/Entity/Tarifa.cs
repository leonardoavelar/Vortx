namespace VxTel.Domain.Entity
{
    public partial class Tarifa : BaseEntity
    {
        public string DddOrigem { get; private set; }

        public string DddDestino { get; private set; }

        public double Valor { get; private set; }

        public Tarifa(int id, string dddOrigem, string dddDestino, double valor)
            : base(id)
        {
            DddOrigem = dddOrigem;
            DddDestino = dddDestino;
            Valor = valor;
        }
    }
}
