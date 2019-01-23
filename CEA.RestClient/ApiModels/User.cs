namespace CEA.RestClient.ApiModels
{
    internal class UserLogin
    {
        public string PinCode { get; set; }
        public string UserName { get; set; }
        public string AuthToken { get; set; }
    }
}