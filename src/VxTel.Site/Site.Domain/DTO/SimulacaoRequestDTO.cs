using System;
using System.ComponentModel.DataAnnotations;

namespace VxTel.Site.Domain.DTO
{
    public class SimulacaoRequestDTO
    {
        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "DDD Origem")]
        public string DddOrigem { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "DDD Destino")]
        public string DddDestino { get; set; }

        [Required(ErrorMessage = "{0} required")]
        [Display(Name = "Tempo")]
        public TimeSpan TempoSimulado { get; set; }

        public bool Simular { get; set; } = false;

        public SimulacaoRequestDTO() { }
    }
}
