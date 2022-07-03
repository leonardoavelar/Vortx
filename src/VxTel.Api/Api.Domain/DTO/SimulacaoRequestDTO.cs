using System;
using System.ComponentModel.DataAnnotations;

namespace VxTel.Api.Domain.DTO
{
    public class SimulacaoRequestDTO
    {
        [Display(Name = "Id Tarifa")]
        public int TarifaId { get; set; }

        [Display(Name = "Tempo")]
        public TimeSpan TempoSimulado { get; set; }
    }
}
