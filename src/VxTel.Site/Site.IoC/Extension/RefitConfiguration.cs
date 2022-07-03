using Polly;
using Polly.Extensions.Http;
using Refit;
using VxTel.Site.Domain.Interface.Refit;
using VxTel.Site.IoC.Policy;

namespace VxTel.Site.IoC.Extension
{
    public static class RefitConfiguration
    {
        public static void ConfigureServicesRefit(this IServiceCollection services, IConfiguration configuration)
        {
            var refitClientConfiguration = new List<HttpClientPolicyConfiguration>();
            configuration.GetSection("RefitClient").Bind(refitClientConfiguration);

            // Configura os Clients baseado no AppSettings.json
            ConfigureRefitClient<IProdutoRefit>(services, refitClientConfiguration.FirstOrDefault(x => x.Name == nameof(IProdutoRefit)));
            ConfigureRefitClient<ISimulacaoRefit>(services, refitClientConfiguration.FirstOrDefault(x => x.Name == nameof(ISimulacaoRefit)));
            ConfigureRefitClient<ITarifaRefit>(services, refitClientConfiguration.FirstOrDefault(x => x.Name == nameof(ITarifaRefit)));
        }

        private static void ConfigureRefitClient<T>(this IServiceCollection services, HttpClientPolicyConfiguration? httpClientPolicyConfiguration)
            where T : class
        {
            if (httpClientPolicyConfiguration is not null)
            {
                services.AddRefitClient<T>().ConfigureHttpClient(client =>
                    {
                        client.BaseAddress = new Uri(httpClientPolicyConfiguration.Url);
                        client.Timeout = TimeSpan.FromSeconds(httpClientPolicyConfiguration.TimeOut);
                    })
                .AddPolicyHandler(GetWaitAndRetryPolicy(httpClientPolicyConfiguration.WaitAndRetryPolicy))
                .AddPolicyHandler(GetCircuitBreakerPolicy(httpClientPolicyConfiguration.CircuitBreakerPolicy));
            }
        }

        private static IAsyncPolicy<HttpResponseMessage>? GetWaitAndRetryPolicy(WaitAndRetryPolicyConfiguration? waitAndRetryPolicyConfiguration)
        {
            if (waitAndRetryPolicyConfiguration is null)
                return null;

            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .WaitAndRetryAsync(retryCount: waitAndRetryPolicyConfiguration.RetryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(waitAndRetryPolicyConfiguration.RetryAttempt, retryAttempt)));
        }

        private static IAsyncPolicy<HttpResponseMessage>? GetCircuitBreakerPolicy(CircuitBreakerPolicyConfiguration? circuitBreakerPolicyConfiguration)
        {
            if (circuitBreakerPolicyConfiguration is null)
                return null;

            return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(handledEventsAllowedBeforeBreaking: circuitBreakerPolicyConfiguration.HandledEventsAllowedBeforeBreaking,
                                     durationOfBreak: TimeSpan.FromSeconds(circuitBreakerPolicyConfiguration.DurationOfBreak));
        }
    }
}