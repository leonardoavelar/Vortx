using System;

namespace VxTel.Domain.Entity
{
    public partial class Consumo
    {
        public int Id { get; private set; }

        public int IdCliente { get; private set; }

        public TimeOnly TempoTotal { get; private set; }

        public double Valor { get; private set; }

        public virtual Cliente Cliente { get; private set; }

        public Consumo(int id, int idCliente, TimeOnly tempoTotal, double valor)
        {
            Id = id;
            IdCliente = idCliente;
            TempoTotal = tempoTotal;
            Valor = valor;
        }
    }
}
