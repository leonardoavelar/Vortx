using System;

namespace VxTel.Domain.Entity
{
    public sealed class Produto
    {
        public int Id { get; private set; }

        public string Nome { get; private set; }

        public TimeSpan TempoContratado { get; private set; }

        public float PercentualAcrescimo { get; private set; }

        public float Valor { get; private set; }

        public Produto(int id, string nome, TimeSpan tempoContratado, float percentualAcrescimo, float valor)
        {
            Id = id;
            Nome = nome;
            TempoContratado = tempoContratado;
            PercentualAcrescimo = percentualAcrescimo;
            Valor = valor;
        }
    }
}
