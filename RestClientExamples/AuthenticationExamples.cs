using System;
using CEA.RestClient;
using CEA.RestClient.Rest;

namespace RestClientExamples
{
    static class AuthenticationExamples
    {
        private const string AppKey = Program.AppKey;
        private const string SecretKey = Program.SecretKey;

        // A helper function for the examples
        // to prompt for the Text-Em-All username and password and set the access token on the Api client
        public static void SetAccessTokenByPromptingForLogin(this RestClient apiClient)
        {
            Console.Write($"Please enter your Text-Em-All username: ");
            var userName = Console.ReadLine();

            Console.Write($"Please enter your Text-Em-All password: ");
            var password = Console.ReadLine();

            apiClient.SetAccessToken(userName, password);
        }

        // This is the way to set the access token on the Api client, 
        // if you know the user's Text-Em-All username and password
        public static void SetAccessToken(this RestClient apiClient, string userName, string password)
        {
            // set Api keys on client
            apiClient.SetOAuthAuthentication(AppKey, SecretKey);

            // get authorization token using Text-Em-All username/password
            var authToken = apiClient.GetAuthorizationToken(userName, password);

            // set authorization token in client
            apiClient.SetAccessToken(authToken);
        }

        // This is the way to set the access token on the Api client,
        // if you already have the token
        public static void SetAccessToken(this RestClient apiClient, string authToken)
        {
            // set authorization token in client
            apiClient.SetOAuthAuthentication(AppKey, SecretKey, authToken);
        }
    }
}
