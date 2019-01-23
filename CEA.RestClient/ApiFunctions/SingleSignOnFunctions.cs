using System.Collections.Generic;

namespace CEA.RestClient
{
    using Rest;
    using ApiModels;

    public static class SingleSignOnFunctions
    {
        /// <summary>
        /// Get a single-sign-on URL for the Call-Em-All site's conversations page
        /// </summary>
        /// <param name="client">The staging or production Call-Em-All rest client</param>
        /// <returns>The URL that can be opened in an IFrame or browser window</returns>
        public static string GetConversationsPageUrl(this RestClient client)
        {
            return client.GetSingleSignOnConversationUrl(new Conversation());
        }

        /// <summary>
        /// Get a single-sign-on URL for the Call-Em-All site's conversation message thread view
        /// </summary>
        /// <param name="client">The staging or production Call-Em-All rest client</param>
        /// <param name="textPhoneNumber">A toll free text number on the Call-Em-All account. E.g. 18885551234</param>
        /// <param name="phoneNumber">A phone number that the toll free text number has a conversation with. E.g. 9725551212</param>
        /// <returns>The URL that can be opened in an IFrame or browser window</returns>
        public static string GetConversationThreadUrl(this RestClient client, string textPhoneNumber, string phoneNumber)
        {
            var conversation = new Conversation
            {
                TextNumber = textPhoneNumber,
                PhoneNumber = phoneNumber
            };

            return client.GetSingleSignOnConversationUrl(conversation);
        }

        /// <summary>
        /// Get a single-sign-on URL for the Call-Em-All site's create broadcast page
        /// with contacts passed in already populated on the page.
        /// </summary>
        /// <param name="client">The staging or production Call-Em-All rest client</param>
        /// <param name="contacts">Contacts to be passed for the create broadcast page</param>
        /// <returns>The URL that can be opened in an IFrame or browser window</returns>
        public static string GetCreateBroadcastPageUrl(this RestClient client, List<Person> contacts = null)
        {
            var draftBroadcast = new DraftBroadcast
            {
                Contacts = contacts
            };

            var response = client.Post("/v1/draftbroadcasts", draftBroadcast);

            return response?.SingleSignOnUrl;
        }

        #region private functions

        private static string GetSingleSignOnConversationUrl(this RestClient client, Conversation conversation)
        {
            var response = client.Post<Conversation, SingleSignOnToken>("/v1/singlesignon/conversations", conversation);

            return response?.Url;
        }

        #endregion
    }
}
