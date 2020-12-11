using System;
using System.Linq;
using CEA.RestClient;
using CEA.RestClient.ApiModels;

namespace RestClientExamples
{
    public class TextConversationExamples
    {
        private const string AppKey = Program.AppKey;
        private const string SecretKey = Program.SecretKey;

        // Example: Send a conversation text message
        //
        // Note: A message to a single contact sent immediately
        public static void SendTextMessage()
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

                // if you already have the ID stored for the toll free text-number 
                // that you want to send the message out on (e.g. 18885551234), you can use that
                
                // or you can look up one that the user has access to:
                var textNumbers = client.Get<Feed<TextNumber>>("/v1/textnumbers");
                var textNumber = textNumbers.Items.FirstOrDefault();

                if (textNumber == null) throw new Exception("The user does not have a toll free text number set up yet.");

                var textMessageToSend = new TextMessage
                {
                    Message = text,
                    Contact = new Person { PrimaryPhone = phoneNumber }
                };

                var conversation = new TextConversation
                {
                    TextNumberID = textNumber.TextNumberID,
                    LastMessage = textMessageToSend
                };

                // create broadcast
                var result = client.Post("/v1/conversations", conversation);
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
