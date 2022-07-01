using System;

namespace VxTel.Api.Domain.DTO
{
    public class ConsumoDTO : BaseDTO
    {
        public int ClienteId { get; set; }

        public ClienteDTO Cliente { get; set; }

        public TimeSpan TempoTotal { get; set; }

        public double Valor { get; set; }

        public ConsumoDTO() { }

        public ConsumoDTO(int id, int clienteId, TimeSpan tempoTotal, double valor)
            : base(id)
        {
            SetValue(clienteId, tempoTotal, valor);
        }

        public ConsumoDTO(int clienteId, TimeSpan tempoTotal, double valor)
        {
            SetValue(clienteId, tempoTotal, valor);
        }

        private void SetValue(int clienteId, TimeSpan tempoTotal, double valor)
        {
            ClienteId = clienteId;
            TempoTotal = tempoTotal;
            Valor = valor;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;

            return obj is ConsumoDTO consumo &&
                   Id == consumo.Id &&
                   ClienteId == consumo.ClienteId &&
                   TempoTotal.Equals(consumo.TempoTotal) &&
                   Valor == consumo.Valor;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, ClienteId, TempoTotal, Valor);
        }
    }
}
