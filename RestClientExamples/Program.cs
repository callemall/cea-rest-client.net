using System;
using System.Diagnostics;
using CEA.RestClient;

namespace RestClientExamples
{
    class Program
    {
        private const string AppKey = ".....";   // please use your API keys provided by Call-Em-All
        private const string SecretKey = "..../";

        // Example 1: Open the Call-Em-All conversation page in a browser
        static void Main(string[] args)
        {
            var client = new StagingRestClient();

            try
            {
                Console.Write($"Please enter your Call-Em-All username: ");
                var userName = Console.ReadLine();

                Console.Write($"Please enter your Call-Em-All password: ");
                var password = Console.ReadLine();

                client.SetOAuthAuthentication(AppKey, SecretKey);

                // get authorization token using Call-Em-All username/password
                var authToken = client.GetAuthorizationToken(userName, password);

                client.SetOAuthAuthentication(AppKey, SecretKey, authToken);

                // get single-sign-on URL for conversations
                var urlToOpen = client.GetConversationsPageUrl();

                // open browser (windows OS)
                Process.Start(new ProcessStartInfo("cmd", $"/c start {urlToOpen}"));
            }
            catch (Exception exception)
            {
                Console.WriteLine($"There was an error: {exception}");
            }

            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }
    }
}
