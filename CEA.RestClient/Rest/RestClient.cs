using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace CEA.RestClient.Rest
{
    public class RestClient
    {
        private const string ContentTypeJSON = @"application/json";

        private enum HttpVerb
        {
            GET,
            POST,
            PUT,
            DELETE
        }

        private IRestClientAuth _authentication;

        public string RestApiUrl { get; set; }

        public int Timeout { get; set; }

        // constructor with basic authentication
        public RestClient(string restApiUrl, string userName, string password) : this(restApiUrl)
        {
            SetBasicAuthentication(userName, password);
        }

        // constructor with OAuth1 authentication
        public RestClient(string restApiUrl, string consumerKey, string secretKey, string authToken) : this(restApiUrl)
        {
            SetOAuthAuthentication(consumerKey, secretKey, authToken);
        }

        internal RestClient(string restApiUrl, IRestClientAuth authentication = null)
        {
            RestApiUrl = restApiUrl;
            _authentication = authentication ?? new RestClientNoAuthentication();
        }

        public void SetBasicAuthentication(string userName, string password)
        {
            _authentication = new RestClientBasicAuthentication(userName, password);
        }

        public void SetOAuthAuthentication(string consumerKey, string secretKey, string authToken = null)
        {
            _authentication = new RestClientOAuth1(consumerKey, secretKey, authToken);
        }

        public T Get<T>(string uri)
            where T : class
        {
            return Execute<T, T>(uri, HttpVerb.GET);
        }

        public TOut Post<TIn, TOut>(string uri, TIn content)
            where TIn : class
        {
            return Execute<TIn, TOut>(uri, HttpVerb.POST, content);
        }

        public T Post<T>(string uri, T content)
            where T : class
        {
            return Execute<T, T>(uri, HttpVerb.POST, content);
        }

        public TOut Put<TIn, TOut>(string uri, TIn content)
            where TIn : class
        {
            return Execute<TIn, TOut>(uri, HttpVerb.PUT, content);
        }

        public T Put<T>(string uri, T content)
            where T : class
        {
            return Execute<T, T>(uri, HttpVerb.PUT, content);
        }

        public void Delete(string uri)
        {
            Execute<string, string>(uri, HttpVerb.DELETE);
        }

        public TOut Delete<TIn, TOut>(string uri, TIn content) where TIn : class
        {
            return Execute<TIn, TOut>(uri, HttpVerb.DELETE, content);
        }

        private TOut Execute<TIn, TOut>(string uri, HttpVerb method, TIn content = null) where TIn : class
        {
            var request = (HttpWebRequest)WebRequest.Create(UrlCompose(RestApiUrl, uri));

            request.ContentType = ContentTypeJSON;
            request.Accept = ContentTypeJSON;
            request.Method = method.ToString();

            if (Timeout > 0) request.Timeout = Timeout;

            _authentication.AddAuthentication(request);

            // add data to the message body.
            if (content != null)
            {
                // Convert the body content into a JSON string
                using (var streamWriter = new StreamWriter(request.GetRequestStream()))
                {
                    var body = JsonConvert.SerializeObject(content); 

                    streamWriter.Write(body);
                }
            }
            else
            {
                request.ContentLength = 0;
            }

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                // Grab the response, convert it into a class TOut object and return the object.
                using (var responseStream = response.GetResponseStream())
                {
                    if (responseStream == null)
                    {
                        throw new Exception("Null response stream.");
                    }

                    var reader = new StreamReader(responseStream, Encoding.UTF8);

                    var responseBody = reader.ReadToEnd();

                    if (typeof(TOut) == typeof(string) || typeof(TOut) == typeof(string)) return (TOut)Convert.ChangeType(responseBody, typeof(TOut));

                    var responseObj = JsonConvert.DeserializeObject<TOut>(responseBody);

                    if (responseObj.GetType().IsAssignableFrom(typeof(TOut)))
                    {
                        return responseObj;
                    }

                    throw new Exception("Response object's type is invalid.");
                }
            }
        }

        private static string UrlCompose(string baseUri, string uri)
        {
            var baseUriObject = new Uri(baseUri);

            var uriComposed = new Uri(baseUriObject, uri);

            return uriComposed.AbsoluteUri;
        }
    }
}
