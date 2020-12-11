namespace CEA.RestClient.ApiModels
{
    public class TextMessage
    {
        public string Message { get; set; }
        public bool TruncateIfExceedsLimit { get; set; }

        public Person Contact { get; set; }
    }
}
