namespace CEA.RestClient
{
    using Rest;

    /// <summary>
    /// Client to access the Call-Em-All staging rest-api's beta functionality
    /// </summary>
    public class StagingBetaRestClient : RestClient
    {
        public StagingBetaRestClient() : base("https://feature-rest.call-em-all.com")
        {
        }
    }
}