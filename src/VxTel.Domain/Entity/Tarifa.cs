namespace VxTel.Domain.Entity
{
    public partial class Tarifa : BaseEntity
    {
        public string DddOrigem { get; private set; }

        public string DddDestino { get; private set; }

        public double Valor { get; private set; }
    }
}
