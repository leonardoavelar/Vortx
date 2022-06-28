using System;
using VxTel.Domain.Enum;

namespace VxTel.Domain.Entity
{
    public sealed class Chamada
    {
        public int Id { get; private set; }

        public int IdCliente { get; private set; }

        public int DddOrigem { get; private set; }

        public long TelefoneOrigem { get; private set; }

        public int DddDestino { get; private set; }

        public long TelefoneDestino { get; private set; }

        public DateTime DataChamada { get; private set; }

        public SituacaoChamada Situacao { get; private set; }

        public DateTime DataHoraInicio { get; private set; }

        public DateTime DataHoraFim { get; private set; }

        public TimeSpan TempoDuracao { get; private set; }

        public float Valor { get; private set; }

        public Chamada(int id, int idCliente, int dddOrigem, long telefoneOrigem, int dddDestino, long telefoneDestino, DateTime dataChamada, SituacaoChamada situacao)
        {
            Id = id;
            IdCliente = idCliente;
            DddOrigem = dddOrigem;
            TelefoneOrigem = telefoneOrigem;
            DddDestino = dddDestino;
            TelefoneDestino = telefoneDestino;
            DataChamada = dataChamada;
            Situacao = situacao;
        }

    }
}
