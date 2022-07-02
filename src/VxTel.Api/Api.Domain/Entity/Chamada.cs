using System;

namespace VxTel.Api.Domain.Entity
{
    public partial class Chamada : BaseEntity
    {
        public int ClienteId { get; private set; }

        public virtual Cliente Cliente { get; private set; }

        public string DddOrigem { get; private set; }

        public long TelefoneOrigem { get; private set; }

        public string DddDestino { get; private set; }

        public long TelefoneDestino { get; private set; }

        public DateTime DataChamada { get; private set; }

        public DateTime? DataHoraInicio { get; private set; }

        public DateTime? DataHoraFim { get; private set; }

        public TimeSpan? TempoDuracao { get; private set; }

        public double? Valor { get; private set; }
    }
}
