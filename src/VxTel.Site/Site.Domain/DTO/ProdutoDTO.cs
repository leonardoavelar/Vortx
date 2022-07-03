using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace VxTel.Site.Domain.DTO
{
    public class ProdutoDTO : BaseDTO
    {
        [Required(ErrorMessage = "{0} required")]
        [StringLength(50)]
        [Display(Name = "Nome Produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.Duration)]
        [Display(Name = "Tempo Contratado")]
        public TimeSpan TempoContratado { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Percentual de Acréscimo")]
        public double PercentualAcrescimo { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.Currency)]
        [Display(Name = "Valor Produto")]
        public double Valor { get; set; }

        public ICollection<ContratoDTO> Contratos { get; set; }

        public ProdutoDTO() { }

        public ProdutoDTO(int id, string nome, TimeSpan tempoContratado, double percentualAcrescimo, double valor)
            : base(id)
        {
            SetValue(nome, tempoContratado, percentualAcrescimo, valor);
        }

        public ProdutoDTO(string nome, TimeSpan tempoContratado, double percentualAcrescimo, double valor)
        {
            SetValue(nome, tempoContratado, percentualAcrescimo, valor);
        }

        private void SetValue(string nome, TimeSpan tempoContratado, double percentualAcrescimo, double valor)
        {
            Nome = nome;
            TempoContratado = tempoContratado;
            PercentualAcrescimo = percentualAcrescimo;
            Valor = valor;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;

            return obj is ProdutoDTO produto &&
                   Id == produto.Id &&
                   Nome == produto.Nome &&
                   TempoContratado == produto.TempoContratado &&
                   PercentualAcrescimo == produto.PercentualAcrescimo &&
                   Valor == produto.Valor;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, TempoContratado, PercentualAcrescimo, Valor);
        }
    }
}
