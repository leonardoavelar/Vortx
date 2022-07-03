using System;
using System.ComponentModel.DataAnnotations;

namespace VxTel.Api.Domain.DTO
{
    public class SimulacaoRequestDTO
    {
        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Id Tarifa")]
        public int TarifaId { get; set; }

        public string DddOrigem { get; set; }

        public string DddDestino { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Tempo")]
        public TimeSpan TempoSimulado { get; set; }

        public bool Simular { get; set; } = false;

        public SimulacaoRequestDTO() { }
    }
}
