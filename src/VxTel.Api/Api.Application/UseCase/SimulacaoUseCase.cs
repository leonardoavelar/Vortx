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

        public async Task<IEnumerable<SimulacaoDTO>> GetSimulacaoAsync(SimulacaoRequestDTO simulacaoRequest)
        {
            var result = new List<SimulacaoDTO>();

            if (simulacaoRequest is null)
                return result;

            var tarifa = await _tarifaService.FindByIdAsync(simulacaoRequest.TarifaId);

            if (tarifa == null)
                return result;

            var produtos = await _produtoService.FindAllAsync();

            produtos.ToList()
                .ForEach(async (produto) => result.Add(await SimularValores(simulacaoRequest, tarifa, produto)));

            return result;
        }

        private async Task<SimulacaoDTO> SimularValores(SimulacaoRequestDTO simulacaoRequest, TarifaDTO tarifa, ProdutoDTO produto)
        {
            var result = new SimulacaoDTO()
            {
                DddOrigem = tarifa.DddOrigem,
                DddDestino = tarifa.DddDestino,
                ProdutoDTO = produto,
                Tempo = simulacaoRequest.TempoSimulado,
                ValorComProduto = await CalcularCustoComProduto(simulacaoRequest.TempoSimulado, tarifa.Valor, produto),
                ValorSemProduto = await CalcularCustoSemProduto(simulacaoRequest.TempoSimulado, tarifa.Valor)
            };

            return result;
        }

        private Task<double> CalcularCustoComProduto(TimeSpan tempoSimulado, double valorTarifa, ProdutoDTO produto)
        {
            double total = 0;
            var possuiAcrescimo = (tempoSimulado > produto.TempoContratado);
            var tempoSemAcrescimo = produto.TempoContratado;
            var tempoComAcrescimo = tempoSimulado - produto.TempoContratado;

            if (possuiAcrescimo)
            {
                total += (valorTarifa * tempoSemAcrescimo.TotalMinutes);
                total += ((valorTarifa * produto.PercentualAcrescimo) * tempoComAcrescimo.TotalMinutes);
            }
            else
            {
                total += (valorTarifa * tempoSimulado.TotalMinutes);
            }

            return Task.FromResult(total);
        }

        private Task<double> CalcularCustoSemProduto(TimeSpan tempoSimulado, double valorTarifa)
        {
            double total = (valorTarifa * tempoSimulado.TotalMinutes);
            return Task.FromResult(total);
        }
    }
}
