namespace CEA.RestClient.ApiModels
{
    internal class SingleSignOnToken
    {
        public string Token { get; set; }
        public string Expires { get; set; }
        public string Url { get; set; }
        public string Created { get; set; }
    }
}
