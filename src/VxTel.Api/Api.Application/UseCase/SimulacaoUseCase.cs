using VxTel.Api.Domain.DTO;
using VxTel.Api.Domain.Interface.Service;
using VxTel.Api.Domain.Interface.UseCase;

namespace VxTel.Api.Application.UseCase
{
    public class SimulacaoUseCase : ISimulacaoUseCase
    {
        private readonly ITarifaService _tarifaService;
        private readonly IProdutoService _produtoService;

        public SimulacaoUseCase(ITarifaService tarifaService, IProdutoService produtoService)
        {
            _tarifaService = tarifaService;
            _produtoService = produtoService;
        }

        public async Task<SimulacaoResponseDTO> SimulacaoAsync(SimulacaoRequestDTO simulacaoRequest)
        {
            var result = new SimulacaoResponseDTO
            {
                SimulacaoRequest = simulacaoRequest
            };

            if (simulacaoRequest is null || 
                simulacaoRequest.TempoSimulado.TotalMinutes == 0 ||
                string.IsNullOrEmpty(simulacaoRequest.DddOrigem) ||
                string.IsNullOrEmpty(simulacaoRequest.DddDestino))
                return result;

            var tarifa = await _tarifaService.FindByOrigemDestinoAsync(simulacaoRequest.DddOrigem, simulacaoRequest.DddDestino);

            if (tarifa is null)
                tarifa = new TarifaDTO() 
                {
                    DddOrigem = simulacaoRequest.DddOrigem,
                    DddDestino = simulacaoRequest.DddDestino,
                    Valor = 0
                };

            var produtos = await _produtoService.FindAllAsync();

            if (produtos is not null)
                result.Simulacao = produtos.Select(x => SimularValores(simulacaoRequest, tarifa, x));
            
            return result;
        }

        private static SimulacaoDTO SimularValores(SimulacaoRequestDTO simulacaoRequest, TarifaDTO tarifa, ProdutoDTO produto)
        {
            var result = new SimulacaoDTO()
            {
                DddOrigem = tarifa.DddOrigem,
                DddDestino = tarifa.DddDestino,
                Produto = produto,
                Tempo = simulacaoRequest.TempoSimulado,
                ValorComProduto = CalcularCustoComProduto(simulacaoRequest.TempoSimulado, tarifa.Valor, produto),
                ValorSemProduto = CalcularCustoSemProduto(simulacaoRequest.TempoSimulado, tarifa.Valor)
            };

            return result;
        }

        private static double CalcularCustoComProduto(TimeSpan tempoSimulado, double valorTarifa, ProdutoDTO produto)
        {
            double total = 0;
            var possuiAcrescimo = (tempoSimulado > produto.TempoContratado);

            if (possuiAcrescimo)
            {
                var tempoComAcrescimo = tempoSimulado - produto.TempoContratado;
                var ValorTarifaAcrescimo = valorTarifa * (produto.PercentualAcrescimo / 100);
                total += ((valorTarifa + ValorTarifaAcrescimo) * tempoComAcrescimo.TotalMinutes);
            }

            return total;
        }

        private static double CalcularCustoSemProduto(TimeSpan tempoSimulado, double valorTarifa)
        {
            double total = (valorTarifa * tempoSimulado.TotalMinutes);
            return total;
        }
    }
}
