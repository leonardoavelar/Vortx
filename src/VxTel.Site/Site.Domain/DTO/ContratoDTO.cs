using System;
using System.ComponentModel.DataAnnotations;

namespace VxTel.Site.Domain.DTO
{
    public class ContratoDTO : BaseDTO
    {
        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Id Cliente")]
        public int ClienteId { get; set; }

        public ClienteDTO Cliente { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Id Produto")]
        public int ProdutoId { get; set; }

        public ProdutoDTO Produto { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        [Display(Name = "Data Contratação")]
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
