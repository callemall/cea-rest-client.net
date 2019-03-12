using System;
using System.Collections.Generic;
using CEA.RestClient;
using CEA.RestClient.ApiModels;

namespace RestClientExamples
{
    class Program
    {
        private const string AppKey = ".....";   // please use your API keys provided by Call-Em-All
        private const string SecretKey = "..../";

        // Example: Send a voice broadcast using text to speech
        static void Main(string[] args)
        {
            var client = new StagingBetaRestClient();

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

                // e.g. your own phone number
                Console.Write($"Please enter a phone number to call: ");
                var phoneNumber = Console.ReadLine();

                // e.g. Hi everyone! This is my first test. Say 1 2 3 4 5 6 7 8 9 10. Goodbye! 
                Console.Write($"Please enter a longer than 10 seconds text to speech message to play: ");
                var textToSpeech = Console.ReadLine();

                broadcast.Contacts = new List<Person>
                {
                    new Person { PrimaryPhone = phoneNumber }
                };

                broadcast.Audio = new Audio
                {
                    TextToSpeech = true,
                    Text = textToSpeech
                };

                // get single-sign-on URL for conversations
                var result = client.Post("/v1/broadcasts", broadcast);
            }
            catch (Exception exception)
            {
                Console.WriteLine($"There was an error: {exception}");
            }

            Console.WriteLine("Press any key to close...");
            Console.ReadKey();
        }

        static readonly Broadcast broadcast = new Broadcast
        {
            BroadcastName = "Test broadcast",
            BroadcastType = "Announcement",
            PrimaryPhoneNumbersOnly = true,
        };
    }
}
