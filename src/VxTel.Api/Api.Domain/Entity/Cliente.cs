using System.Collections.Generic;

namespace VxTel.Api.Domain.Entity
{
    public partial class Cliente : BaseEntity
    {
        public string Nome { get; private set; }

        public string Documento { get; private set; }

        public string Ddd { get; private set; }

        public long Telefone { get; private set; }

        public virtual ICollection<Chamada> Chamadas { get; private set; }

        public virtual ICollection<Consumo> Consumos { get; private set; }

        public virtual ICollection<Contrato> Contratos { get; private set; }
    }
}
