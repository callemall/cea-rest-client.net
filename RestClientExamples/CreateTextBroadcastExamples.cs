using System;
using System.Collections.Generic;
using CEA.RestClient;
using CEA.RestClient.ApiModels;
namespace RestClientExamples
{
    public class CreateTextBroadcastExamples
    {
        private const string AppKey = Program.AppKey;
        private const string SecretKey = Program.SecretKey;

        // Example: Send a text broadcast 
        //
        // Note: Although a broadcast can go to as many recipients as you need
        //       in this example, we only prompt for one phone number
        public static void CreateTextBroadcast()
        {
            var client = new StagingRestClient();

            try
            {
                // if you already have the user's authorization token, you can use it, like this:
                // client.SetAccessToken("pass in the token here");

                // or prompt the user for their Text-Em-All username/password
                client.SetAccessTokenByPromptingForLogin();

                // enter a phone number to text
                // e.g. your own
                Console.Write($"Please enter a phone number to text: ");
                var phoneNumber = Console.ReadLine();

                // enter a text to send
                // please make it not spammy or salesy 
                Console.Write($"Please enter a text message to send: ");
                var text = Console.ReadLine();

                var broadcast = new Broadcast
                {
                    BroadcastName = "Test broadcast",
                    BroadcastType = "SMS",
                    PrimaryPhoneNumbersOnly = true,

                    // contacts
                    Contacts = new List<Person>
                    {
                        new Person { PrimaryPhone = phoneNumber },
                        // add additional contacts if needed
                        // new Person { PrimaryPhone = phoneNumber, FirstName = "Optional", LastName = "Optional", Notes = "Optional" }
                    },

                    // message
                    TextMessage = text
                };

                // create broadcast
                var result = client.Post("/v1/broadcasts", broadcast);
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
