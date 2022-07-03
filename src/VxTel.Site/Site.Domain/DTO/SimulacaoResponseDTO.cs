using System.Collections.Generic;

namespace VxTel.Site.Domain.DTO
{
    public class SimulacaoResponseDTO
    {
        public SimulacaoRequestDTO SimulacaoRequest { get; set; }

        public IEnumerable<SimulacaoDTO> Simulacao { get; set; } = new List<SimulacaoDTO>();

        public SimulacaoResponseDTO() { }
    }
}
