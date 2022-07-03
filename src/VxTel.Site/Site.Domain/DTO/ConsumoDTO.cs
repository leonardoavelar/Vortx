using System;
using System.ComponentModel.DataAnnotations;

namespace VxTel.Site.Domain.DTO
{
    public class ConsumoDTO : BaseDTO
    {
        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Id Cliente")]
        public int ClienteId { get; set; }

        public ClienteDTO Cliente { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{HH:mm:ss}")]
        [Display(Name = "Tempo Consumido")]
        public TimeSpan TempoTotal { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Valor")]
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
