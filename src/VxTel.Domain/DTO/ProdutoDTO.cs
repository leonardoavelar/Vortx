using System;
using System.Collections.Generic;

namespace VxTel.Domain.DTO
{
    public class ProdutoDTO : BaseDTO
    {
        public string Nome { get; set; }

        public TimeSpan TempoContratado { get; set; }

        public double PercentualAcrescimo { get; set; }

        public double Valor { get; set; }

        public ICollection<ContratoDTO> Contratos { get; set; }

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
                   TempoContratado.Equals(produto.TempoContratado) &&
                   PercentualAcrescimo == produto.PercentualAcrescimo &&
                   Valor == produto.Valor;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Nome, TempoContratado, PercentualAcrescimo, Valor, Contratos);
        }
    }
}
