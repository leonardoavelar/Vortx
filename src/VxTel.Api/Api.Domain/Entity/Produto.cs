using System;

namespace VxTel.Api.Domain.Entity
{
    public partial class Produto : BaseEntity
    {
        public string Nome { get; private set; }

        public TimeSpan TempoContratado { get; private set; }

        public double PercentualAcrescimo { get; private set; }

        public double Valor { get; private set; }
    }
}
