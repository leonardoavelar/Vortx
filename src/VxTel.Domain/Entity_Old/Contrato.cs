using System;

namespace VxTel.Domain.Entity
{
    public sealed class Contrato
    {
        public int Id { get; private set; }

        public int IdCliente { get; private set; }

        public int IdProduto { get; private set; }

        public DateTime DataContratacao { get; private set; }

        public Contrato(int id, int idCliente, int idProduto, DateTime dataContratacao)
        {
            Id = id;
            IdCliente = idCliente;
            IdProduto = idProduto;
            DataContratacao = dataContratacao;
        }
    }
}
