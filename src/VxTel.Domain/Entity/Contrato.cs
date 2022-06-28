using System;

namespace VxTel.Domain.Entity
{
    public partial class Contrato : BaseEntity
    {
        public int IdCliente { get; private set; }

        public int IdProduto { get; private set; }

        public DateTime DataContratacao { get; private set; }

        public virtual Cliente Cliente { get; private set; }

        public virtual Produto Produto { get; private set; }

        public Contrato(int id, int idCliente, int idProduto, DateTime dataContratacao)
            : base(id)
        {
            IdCliente = idCliente;
            IdProduto = idProduto;
            DataContratacao = dataContratacao;
        }
    }
}
