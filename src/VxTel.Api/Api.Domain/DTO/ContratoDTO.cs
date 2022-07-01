using System;

namespace VxTel.Api.Domain.DTO
{
    public class ContratoDTO : BaseDTO
    {
        public int ClienteId { get; set; }

        public ClienteDTO Cliente { get; set; }

        public int ProdutoId { get; set; }

        public ProdutoDTO Produto { get; set; }

        public DateTime DataContratacao { get; set; }

        public ContratoDTO() { }

        public ContratoDTO(int id, int clienteId, int produtoId, DateTime dataContratacao)
            : base(id)
        {
            SetValue(clienteId, produtoId, dataContratacao);
        }

        public ContratoDTO(int clienteId, int produtoId, DateTime dataContratacao)
        {
            SetValue(clienteId, produtoId, dataContratacao);
        }

        private void SetValue(int clienteId, int produtoId, DateTime dataContratacao)
        {
            ClienteId = clienteId;
            ProdutoId = produtoId;
            DataContratacao = dataContratacao;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;

            return obj is ContratoDTO contrato &&
                   Id == contrato.Id &&
                   ClienteId == contrato.ClienteId &&
                   ProdutoId == contrato.ProdutoId &&
                   DataContratacao == contrato.DataContratacao;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, ClienteId, ProdutoId, DataContratacao);
        }
    }
}
