namespace CEA.RestClient.ApiModels
{
    public class TextConversation
    {
        public long ConversationID { get; set; }
        public long TextNumberID { get; set; }
        public string PhoneNumber { get; set; }
        public string TextPhoneNumber { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Notes { get; set; }
        public string IntegrationData { get; set; }

        public TextMessage LastMessage { get; set; }
    }
}
