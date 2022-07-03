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

        [Display(Name = "Tempo")]
        public TimeSpan Tempo { get; set; }

        public ProdutoDTO Produto { get; set; }

        [Display(Name = "Valor Com FaleMais")]
        public double ValorComProduto { get; set; }

        [Display(Name = "Valor Sem FaleMais")]

        public double ValorSemProduto { get; set; }

        public SimulacaoDTO() { }
    }
}
