using System;
using System.Collections.Generic;
using CEA.RestClient;
using CEA.RestClient.ApiModels;

namespace RestClientExamples
{
    public class CreateVoiceBroadcastExamples
    {
        private const string AppKey = Program.AppKey;
        private const string SecretKey = Program.SecretKey;

        // Example: Send a voice broadcast using text to speech
        //
        // Note: Although a broadcast can go to as many recipients as you need
        //       in this example, we only prompt for one phone number
        public static void CreateTextToSpeechVoiceBroadcast()
        {
            var client = new StagingRestClient();

            try
            {
                // if you already have the user's authorization token, you can use it, like this:
                // client.SetAccessToken("pass in the token here");

                // or prompt the user for their Text-Em-All username/password
                client.SetAccessTokenByPromptingForLogin();

                // enter a phone number to call
                // e.g. your own
                Console.Write($"Please enter a phone number to call: ");
                var phoneNumber = Console.ReadLine();

                // enter a text to turn into text-to-speech
                // e.g. Hi everyone! This is my first test. Say 11 12 13 14 15 16 17 18 19 20. Goodbye! 
                Console.Write($"Please enter a longer than 10 seconds text to speech message to play: ");
                var textToSpeech = Console.ReadLine();

                var broadcast = new Broadcast
                {
                    BroadcastName = "Test broadcast",
                    BroadcastType = "Announcement",
                    PrimaryPhoneNumbersOnly = true,

                    // contacts
                    Contacts = new List<Person>
                    {
                        new Person { PrimaryPhone = phoneNumber },
                        // add additional contacts if needed
                        // new Person { PrimaryPhone = phoneNumber, FirstName = "Optional", LastName = "Optional", Notes = "Optional" }
                    },

                    // audio
                    Audio = new Audio
                    {
                        TextToSpeech = true,
                        Text = textToSpeech
                    }
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
