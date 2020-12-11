namespace RestClientExamples
{
    class Program
    {
        // please enter your API keys provided by Text-Em-All below
        public const string AppKey = ".....";
        public const string SecretKey = ".....";

        static void Main(string[] args)
        {
            // Example: Send a text broadcast
            CreateTextBroadcastExamples.CreateTextBroadcast();

            // Example: Send an immediate text message
            TextConversationExamples.SendTextMessage();

            // Example: Send a voice broadcast using text-to-speech
            CreateVoiceBroadcastExamples.CreateTextToSpeechVoiceBroadcast();

            // Example: Initiate Single-Sign-On
            SingleSignOnExamples.OpenSingleSignOnConversationsPage();
        }
    }
}
