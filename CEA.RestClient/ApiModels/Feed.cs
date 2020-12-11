using System.Collections.Generic;

namespace CEA.RestClient.ApiModels
{
    public class Feed<T> where T : class
    {
        public int Size { get; set; }
        public List<T> Items { get; set; }
        public string Previous { get; set; }
        public string Next { get; set; }
    }
}