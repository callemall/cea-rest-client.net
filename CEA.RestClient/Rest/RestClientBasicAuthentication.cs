using System;
using System.Text;

namespace CEA.RestClient.Rest
{
    internal class RestClientBasicAuthentication : IRestClientAuth
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public RestClientBasicAuthentication(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public void AddAuthentication(System.Net.HttpWebRequest request)
        {
            var authenticaton = string.Format("{0}:{1}", UserName, Password);
            var encoded = Encoding.ASCII.GetBytes(authenticaton);

            var basicauthentication = string.Format("Basic {0}", Convert.ToBase64String(encoded));

            request.Headers.Add("Authorization", basicauthentication);
        }
    }
}
