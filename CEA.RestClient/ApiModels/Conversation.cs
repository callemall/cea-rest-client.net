namespace CEA.RestClient.ApiModels
{
    internal class Conversation
    {
        public string TextNumber { get; set; }
        public string PhoneNumber { get; set; }
        public ConversationCustomization Customization { get; set; }
    }
}
