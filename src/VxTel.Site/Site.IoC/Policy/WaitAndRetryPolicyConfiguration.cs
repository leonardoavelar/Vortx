namespace VxTel.Site.IoC.Policy
{
    public class WaitAndRetryPolicyConfiguration
    {
        public int RetryCount { get; set; }

        public int RetryAttempt { get; set; }
    }
}
