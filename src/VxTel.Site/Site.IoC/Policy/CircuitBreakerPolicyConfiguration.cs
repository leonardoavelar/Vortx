namespace VxTel.Site.IoC.Policy
{
    public class CircuitBreakerPolicyConfiguration
    {
        public int HandledEventsAllowedBeforeBreaking { get; set; }

        public int DurationOfBreak { get; set; }
    }
}
