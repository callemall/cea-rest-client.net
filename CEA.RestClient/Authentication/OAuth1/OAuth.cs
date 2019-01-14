using System;
using System.Collections.Generic;
using System.Net;

namespace CEA.RestClient.Authentication.OAuth1
{
    internal class OAuth : OAuthBase
    {
        public string ConsumerKey
        {
            get { return GetParameterValue(OAuthConsumerKeyKey); }
        }

        public string Token
        {
            get { return GetParameterValue(OAuthTokenKey); }
        }

        public string Nonce
        {
            get { return GetParameterValue(OAuthNonceKey); }
        }

        public string Timestamp
        {
            get { return GetParameterValue(OAuthTimestampKey); }
        }

        public string SignatureMethod
        {
            get { return GetParameterValue(OAuthSignatureMethodKey); }
        }

        public string Version
        {
            get { return GetParameterValue(OAuthVersionKey); }
        }

        public string Signature
        {
            //get { return HttpUtility.UrlDecode(GetParameterValue(OAuthSignatureKey)); }
            get { return GetParameterValue(OAuthSignatureKey); }
        }

        public Dictionary<string, string> Parameters { get; set; }

        private readonly List<string> _requiredKeys = new List<string>
            {
                OAuthConsumerKeyKey,
                OAuthTokenKey,
                OAuthNonceKey,
                OAuthTimestampKey,
                OAuthSignatureMethodKey,
                OAuthVersionKey,
                OAuthSignatureKey
            };

        public static void AddAuthorizationHeader(HttpWebRequest request, string consumerKey, string token,
                                                  string consumerSecret)
        {
            var myOauth = new OAuth
                {
                    Parameters = new Dictionary<string, string>
                        {
                            {OAuthConsumerKeyKey, consumerKey},
                            {OAuthTokenKey, token},
                            {OAuthSignatureMethodKey, HMACSHA1SignatureType},
                            {OAuthVersionKey, OAuthVersion}
                        }
                }
                .AddNonce()
                .AddTimestamp()
                .AddSignature(request, consumerSecret);

            request.Headers.Add("Authorization", myOauth.GenerateAuthorizationHeaderValue());
        }

        private string GenerateSignature(Uri url, string method, string consumerSecret, out string normalizedUrl,
                                        out string normalizedRequestParameters)
        {
            var generatedSignature = GenerateSignature(url, ConsumerKey.ToLower(), consumerSecret.ToLower(), Token, null,
                                                       method, Timestamp, Nonce, out normalizedUrl,
                                                       out normalizedRequestParameters);

            return generatedSignature;
        }

        private OAuth AddNonce()
        {
            Parameters.Add(OAuthNonceKey, GenerateNonce());
            return this;
        }

        private OAuth AddTimestamp()
        {
            Parameters.Add(OAuthTimestampKey, GenerateTimeStamp());
            return this;
        }

        private OAuth AddSignature(WebRequest request, string consumerSecret)
        {
            if (request == null) throw new ArgumentNullException("request");

            string normalizedUrl, normalizedRequestParameters;
            Parameters.Add(OAuthSignatureKey,
                           //GenerateSignature(new Uri(request.Headers.Get("X-Forwarded-Host")), request.Method,
                           GenerateSignature(request.RequestUri, request.Method,
                                             consumerSecret, out normalizedUrl, out normalizedRequestParameters));

            //to do: need to normalize the request here

            return this;
        }

        private string GenerateAuthorizationHeaderValue()
        {
            return
                string.Format(
                    "OAuth {0}=\"{1}\",{2}=\"{3}\",{4}=\"{5}\",{6}=\"{7}\",{8}=\"{9}\",{10}=\"{11}\",{12}=\"{13}\"",
                    OAuthConsumerKeyKey, ConsumerKey,
                    OAuthTokenKey, Token,
                    OAuthNonceKey, Nonce,
                    OAuthTimestampKey, Timestamp,
                    OAuthSignatureMethodKey, SignatureMethod,
                    OAuthVersionKey, Version,
                    OAuthSignatureKey, UrlEncode(Signature));
        }

        private string GetParameterValue(string key)
        {
            string value;
            if (Parameters.TryGetValue(key, out value)) return value;

            throw new Exception(string.Format("Unable to find parameter '{0}'", key));
        }
    }
}
