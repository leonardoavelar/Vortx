using System;
using System.Collections.Generic;

namespace VxTel.Api.Domain.DTO
{
    public class ChamadaDTO : BaseDTO
    {
        public int ClienteId { get; set; }

        public ClienteDTO Cliente { get; set; }

        public string DddOrigem { get; set; }

        public long TelefoneOrigem { get; set; }

        public string DddDestino { get; set; }

        public long TelefoneDestino { get; set; }

        public DateTime DataChamada { get; set; }

        public DateTime DataHoraInicio { get; set; }

        public DateTime? DataHoraFim { get; set; }

        public TimeSpan? TempoDuracao { get; set; }

        public double? Valor { get; set; }

        public ChamadaDTO() { }

        public ChamadaDTO(int id, int clienteId, string dddOrigem, long telefoneOrigem,
                          string dddDestino, long telefoneDestino, DateTime dataChamada,
                          DateTime dataHoraInicio, DateTime? dataHoraFim, TimeSpan? tempoDuracao, double? valor)
            : base(id)
        {
            SetValue(clienteId, dddOrigem, telefoneOrigem, dddDestino, telefoneDestino, dataChamada, dataHoraInicio, dataHoraFim, tempoDuracao, valor);
        }

        public ChamadaDTO(int clienteId, string dddOrigem, long telefoneOrigem,
                   string dddDestino, long telefoneDestino, DateTime dataChamada,
                   DateTime dataHoraInicio, DateTime? dataHoraFim, TimeSpan? tempoDuracao, double? valor)
        {
            SetValue(clienteId, dddOrigem, telefoneOrigem, dddDestino, telefoneDestino, dataChamada, dataHoraInicio, dataHoraFim, tempoDuracao, valor);
        }

        private void SetValue(int clienteId, string dddOrigem, long telefoneOrigem,
                              string dddDestino, long telefoneDestino, DateTime dataChamada,
                              DateTime dataHoraInicio, DateTime? dataHoraFim, TimeSpan? tempoDuracao, double? valor)
        {
            ClienteId = clienteId;
            DddOrigem = dddOrigem;
            TelefoneOrigem = telefoneOrigem;
            DddDestino = dddDestino;
            TelefoneDestino = telefoneDestino;
            DataChamada = dataChamada;
            DataHoraInicio = dataHoraInicio;
            DataHoraFim = dataHoraFim;
            TempoDuracao = tempoDuracao;
            Valor = valor;
        }

        public override bool Equals(object obj)
        {
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
                return false;

            return obj is ChamadaDTO chamada &&
                   Id == chamada.Id &&
                   ClienteId == chamada.ClienteId &&
                   DddOrigem == chamada.DddOrigem &&
                   TelefoneOrigem == chamada.TelefoneOrigem &&
                   DddDestino == chamada.DddDestino &&
                   TelefoneDestino == chamada.TelefoneDestino &&
                   DataChamada == chamada.DataChamada &&
                   DataHoraInicio == chamada.DataHoraInicio &&
                   DataHoraFim == chamada.DataHoraFim &&
                   TempoDuracao == chamada.TempoDuracao &&
                   Valor == chamada.Valor;
        }

        public override int GetHashCode()
        {
            HashCode hash = new();
            hash.Add(Id);
            hash.Add(ClienteId);
            hash.Add(DddOrigem);
            hash.Add(TelefoneOrigem);
            hash.Add(DddDestino);
            hash.Add(TelefoneDestino);
            hash.Add(DataChamada);
            hash.Add(DataHoraInicio);
            hash.Add(DataHoraFim);
            hash.Add(TempoDuracao);
            hash.Add(Valor);
            return hash.ToHashCode();
        }
    }
}
