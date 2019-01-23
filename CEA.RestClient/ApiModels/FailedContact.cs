namespace CEA.RestClient.ApiModels
{
    public class FailedContact
    {
        public int ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public Person Contact { get; set; }
    }
}
