using System;

namespace VxTel.Api.Domain.Entity
{
    public partial class Contrato : BaseEntity
    {
        public int ClienteId { get; private set; }

        public virtual Cliente Cliente { get; private set; }

        public int ProdutoId { get; private set; }

        public virtual Produto Produto { get; private set; }

        public DateTime DataContratacao { get; private set; }
    }
}
