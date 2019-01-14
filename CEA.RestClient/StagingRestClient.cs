namespace CEA.RestClient
{
    using Rest;

    /// <summary>
    /// Client to access the Call-Em-All staging rest-api
    /// </summary>
    public class StagingRestClient : RestClient
    {
        public StagingRestClient() : base("https://staging-rest.call-em-all.com")
        {
        }
    }
}
