using System;

namespace VxTel.Api.Domain.Entity
{
    public partial class Consumo : BaseEntity
    {
        public int ClienteId { get; private set; }

        public virtual Cliente Cliente { get; private set; }

        public TimeSpan TempoTotal { get; private set; }

        public double Valor { get; private set; }
    }
}
