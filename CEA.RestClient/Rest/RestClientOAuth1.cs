namespace CEA.RestClient.Rest
{
    using Authentication.OAuth1;

    internal class RestClientOAuth1 : IRestClientAuth
    {
        public string ConsumerKey { get; set; }
        public string AuthToken { get; set; }
        public string SecretKey { get; set; }

        public RestClientOAuth1(string consumerKey, string secretKey, string authToken)
        {
            ConsumerKey = consumerKey;
            SecretKey = secretKey;
            AuthToken = authToken ?? new System.Guid().ToString();
        }

        public void AddAuthentication(System.Net.HttpWebRequest request)
        {
            OAuth.AddAuthorizationHeader(request, ConsumerKey, AuthToken, SecretKey);
        }
    }
}
