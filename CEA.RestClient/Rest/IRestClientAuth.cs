using System.Net;

namespace CEA.RestClient.Rest
{
    internal interface IRestClientAuth
    {
        void AddAuthentication(HttpWebRequest request);
    }
}
