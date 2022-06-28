using System;

namespace VxTel.Domain.Entity
{
    public sealed class Consumo
    {
        public int Id { get; private set; }

        public int IdCliente { get; private set; }

        public TimeSpan TempoTotal { get; private set; }

        public float Valor { get; private set; }

        public Consumo(int id, int idCliente, TimeSpan tempoTotal, float valor)
        {
            Id = id;
            IdCliente = idCliente;
            TempoTotal = tempoTotal;
            Valor = valor;
        }
    }
}
