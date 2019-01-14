namespace CEA.RestClient
{
    using Rest;

    /// <summary>
    /// Client to access the Call-Em-All production rest-api
    /// </summary>
    public class ProductionRestClient : RestClient
    {
        public ProductionRestClient() : base("https://rest.call-em-all.com")
        {
        }
    }
}
