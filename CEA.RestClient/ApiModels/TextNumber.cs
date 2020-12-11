namespace CEA.RestClient.ApiModels
{
    public class TextNumber
    {
        public long TextNumberID { get; set; }
        public string TextPhoneNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool? IsDefault { get; set; }
    }
}