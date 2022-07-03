using System;
using System.ComponentModel.DataAnnotations;

namespace VxTel.Api.Domain.DTO
{
    public class SimulacaoDTO
    {
        [Display(Name = "DDD Origem")]
        public string DddOrigem { get; set; }

        [Display(Name = "DDD Destino")]
        public string DddDestino { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Tempo")]
        public TimeSpan Tempo { get; set; }

        public ProdutoDTO Produto { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Valor Com FaleMais")]
        public double ValorComProduto { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Valor Sem FaleMais")]

        public double ValorSemProduto { get; set; }

        public SimulacaoDTO() { }
    }
}
