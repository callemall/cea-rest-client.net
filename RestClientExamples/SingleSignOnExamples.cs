using System;
using System.Diagnostics;
using CEA.RestClient;

namespace RestClientExamples
{
    public class SingleSignOnExamples
    {
        private const string AppKey = Program.AppKey;
        private const string SecretKey = Program.SecretKey;

        // Example: Opn up the full conversations page in single-sign-on
        public static void OpenSingleSignOnConversationsPage()
        {
            var client = new StagingRestClient();

            try
            {
                // if you already have the user's authorization token, you can use it, like this:
                // client.SetAccessToken("pass in the token here");

                // or prompt the user for their Text-Em-All username/password
                client.SetAccessTokenByPromptingForLogin();

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
