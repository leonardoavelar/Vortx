using System;
using System.Collections.Generic;

namespace VxTel.Domain.Entity
{
    public partial class Produto : BaseEntity
    {
        public string Nome { get; private set; }

        public TimeOnly TempoContratado { get; private set; }

        public double PercentualAcrescimo { get; private set; }

        public double Valor { get; private set; }

        public virtual ICollection<Contrato> Contratos { get; private set; }

        public Produto(int id, string nome, TimeOnly tempoContratado, double percentualAcrescimo, double valor)
            : base(id)
        {
            Nome = nome;
            TempoContratado = tempoContratado;
            PercentualAcrescimo = percentualAcrescimo;
            Valor = valor;
            Contratos = new HashSet<Contrato>();
        }
    }
}
