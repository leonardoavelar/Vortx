using System;
using System.Collections.Generic;

namespace VxTel.Domain.Entity
{
    public partial class Produto : BaseEntity
    {
        public string Nome { get; private set; }

        public TimeSpan TempoContratado { get; private set; }

        public double PercentualAcrescimo { get; private set; }

        public double Valor { get; private set; }

        public virtual ICollection<Contrato> Contratos { get; private set; }
    }
}
