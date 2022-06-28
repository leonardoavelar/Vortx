using System;

namespace VxTel.Domain.Entity
{
    public partial class Chamada : BaseEntity
    {
        public int IdCliente { get; private set; }

        public string DddOrigem { get; private set; }

        public long TelefoneOrigem { get; private set; }

        public string DddDestino { get; private set; }

        public long TelefoneDestino { get; private set; }

        public DateTime DataChamada { get; private set; }

        public short Situacao { get; private set; }

        public DateTime? DataHoraInicio { get; private set; }

        public DateTime? DataHoraFim { get; private set; }

        public TimeOnly? TempoDuracao { get; private set; }

        public double? Valor { get; private set; }

        public virtual Cliente Cliente { get; private set; }

        public Chamada (int id, int idCliente, string dddOrigem, long telefoneOrigem, 
                        string dddDestino, long telefoneDestino, DateTime dataChamada, short situacao, 
                        DateTime? dataHoraInicio, DateTime? dataHoraFim, TimeOnly? tempoDuracao, double? valor)
            : base(id)
        {
            IdCliente = idCliente;
            DddOrigem = dddOrigem;
            TelefoneOrigem = telefoneOrigem;
            DddDestino = dddDestino;
            TelefoneDestino = telefoneDestino;
            DataChamada = dataChamada;
            Situacao = situacao;
            DataHoraInicio = dataHoraInicio;
            DataHoraFim = dataHoraFim;
            TempoDuracao = tempoDuracao;
            Valor = valor;
        }
    }
}
