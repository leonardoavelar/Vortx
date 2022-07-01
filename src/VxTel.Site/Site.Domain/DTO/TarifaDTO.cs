using System;

namespace VxTel.Site.Domain.DTO
{
    public class TarifaDTO : BaseDTO
    {
        public string DddOrigem { get; set; }

        public string DddDestino { get; set; }

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
