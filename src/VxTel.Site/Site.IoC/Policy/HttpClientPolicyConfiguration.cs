namespace VxTel.Site.IoC.Policy
{
    public class HttpClientPolicyConfiguration
    {
        public string Name { get; set; } = String.Empty;

        public string Url { get; set; } = String.Empty;

        public int TimeOut { get; set; }

        public WaitAndRetryPolicyConfiguration? WaitAndRetryPolicy { get; set; }

        public CircuitBreakerPolicyConfiguration? CircuitBreakerPolicy { get; set; }
    }
}
