using System;
using System.ComponentModel.DataAnnotations;

namespace VxTel.Site.Domain.DTO
{
    public class TarifaDTO : BaseDTO
    {
        [Required(ErrorMessage = "{0} required")]
        [StringLength(maximumLength: 3, MinimumLength = 3)]
        [Display(Name = "DDD Origem")]
        public string DddOrigem { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(maximumLength: 3, MinimumLength = 3)]
        [Display(Name = "DDD Destino")]
        public string DddDestino { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Valor Tarifa")]
        public double Valor { get; set; }

        public TarifaDTO() { }

        public TarifaDTO(int id, string dddOrigem, string dddDestino, double valor)
            : base(id)
        {
            SetValue(dddOrigem, dddDestino, valor);
        }
        public TarifaDTO(string dddOrigem, string dddDestino, double valor)
        {
            SetValue(dddOrigem, dddDestino, valor);
        }

        private void SetValue(string dddOrigem, string dddDestino, double valor)
        {
            DddOrigem = dddOrigem;
            DddDestino = dddDestino;
            Valor = valor;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;

            return obj is TarifaDTO tarifa &&
                   Id == tarifa.Id &&
                   DddOrigem == tarifa.DddOrigem &&
                   DddDestino == tarifa.DddDestino &&
                   Valor == tarifa.Valor;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, DddOrigem, DddDestino, Valor);
        }
    }
}
