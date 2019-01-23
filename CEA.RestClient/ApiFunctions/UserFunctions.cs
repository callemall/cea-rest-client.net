namespace CEA.RestClient
{
    using Rest;
    using ApiModels;

    public static class UserFunctions
    {
        /// <summary>
        /// Retrieve a user's authentication token for OAuth authentication.
        /// </summary>
        /// <param name="client">The staging or production Call-Em-All rest client</param>
        /// <param name="userName">The user name used for logging in to the Call-Em-All web site.</param>
        /// <param name="password">The password used for logging in to the Call-Em-All web site.</param>
        /// <returns>The user's authorization token</returns>
        public static string GetAuthorizationToken(this RestClient client, string userName, string password)
        {
            var userLogin = new UserLogin
            {
                UserName = userName,
                PinCode = password
            };

            var response = client.Post("/v1/user/login", userLogin);

            return response?.AuthToken;
        }
    }
}