using System.Collections.Generic;

namespace VxTel.Site.Domain.DTO
{
    public class SimulacaoResponseDTO
    {
        public SimulacaoRequestDTO SimulacaoRequest { get; set; }

        public SimulacaoDTO Simulacao { get; set; }

        public SimulacaoResponseDTO() { }
    }
}
