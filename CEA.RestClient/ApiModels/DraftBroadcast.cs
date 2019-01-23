using System.Collections.Generic;

namespace CEA.RestClient.ApiModels
{
    internal class DraftBroadcast
    {
        public List<Person> Contacts { get; set; }
        public long DraftBroadcastID { get; set; }
        public List<FailedContact> FailedContacts { get; set; }
        public string SingleSignOnToken { get; set; }
        public string SingleSignOnUrl { get; set; }
    }
}
