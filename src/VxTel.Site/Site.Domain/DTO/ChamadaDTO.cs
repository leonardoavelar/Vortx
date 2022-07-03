using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using VxTel.Site.Domain.Enum;

namespace VxTel.Site.Domain.DTO
{
    public class ChamadaDTO : BaseDTO
    {
        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Id Cliente")]
        public int ClienteId { get; set; }

        public ClienteDTO Cliente { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(maximumLength: 3, MinimumLength = 3)]
        [Display(Name = "DDD Origem")]
        public string DddOrigem { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(maximumLength: 8, MinimumLength = 9)]
        [Display(Name = "Telefone Origem")]
        public long TelefoneOrigem { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(maximumLength: 3, MinimumLength = 3)]
        [Display(Name = "DDD Destino")]
        public string DddDestino { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [StringLength(maximumLength: 8, MinimumLength = 9)]
        [Display(Name = "Telefone Destino")]
        public long TelefoneDestino { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        [Display(Name = "Data/Hora Início")]
        public DateTime DataHoraInicio { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        [Display(Name = "Data/Hora Término")]
        public DateTime? DataHoraFim { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{HH:mm:ss}")]
        [Display(Name = "Tempo Duração")]
        public TimeSpan? TempoDuracao { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [DataType(DataType.Currency)]
        [Display(Name = "Valor Chamada")]
        public double? Valor { get; set; }

        public ChamadaDTO() { }

        public ChamadaDTO(int id, int clienteId, string dddOrigem, long telefoneOrigem, 
                          string dddDestino, long telefoneDestino, DateTime dataHoraInicio, DateTime? dataHoraFim, TimeSpan? tempoDuracao, double? valor)
            : base(id)
        {
            SetValue(clienteId, dddOrigem, telefoneOrigem, dddDestino, telefoneDestino, dataHoraInicio, dataHoraFim, tempoDuracao, valor);
        }

        public ChamadaDTO(int clienteId, string dddOrigem, long telefoneOrigem,
                   string dddDestino, long telefoneDestino, DateTime dataHoraInicio, DateTime? dataHoraFim, TimeSpan? tempoDuracao, double? valor)
        {
            SetValue(clienteId, dddOrigem, telefoneOrigem, dddDestino, telefoneDestino, dataHoraInicio, dataHoraFim, tempoDuracao, valor);
        }

        private void SetValue(int clienteId, string dddOrigem, long telefoneOrigem, 
                              string dddDestino, long telefoneDestino, DateTime dataHoraInicio, DateTime? dataHoraFim, TimeSpan? tempoDuracao, double? valor)
        {
            ClienteId = clienteId;
            DddOrigem = dddOrigem;
            TelefoneOrigem = telefoneOrigem;
            DddDestino = dddDestino;
            TelefoneDestino = telefoneDestino;
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
            hash.Add(DataHoraInicio);
            hash.Add(DataHoraFim);
            hash.Add(TempoDuracao);
            hash.Add(Valor);
            return hash.ToHashCode();
        }
    }
}
