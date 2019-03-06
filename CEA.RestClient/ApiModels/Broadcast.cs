using System;
using System.Collections.Generic;
using System.Text;

namespace CEA.RestClient.ApiModels
{
    public class Broadcast
    {
        public long BroadcastID { get; set; }
        public string BroadcastName { get; set; }
        public string BroadcastType { get; set; }
        public string StartDate { get; set; }
        public string CallerID { get; set; }
        public string BroadcastStatus { get; set; }
        public string BroadcastStatusCategory { get; set; }
        public string CreatedDate { get; set; }

        // input only for broadcast creation
        public bool? CheckCallingWindow { get; set; }
        public bool? ContinueOnNextDay { get; set; }
        public List<List> Lists { get; set; }
        public List<Person> Contacts { get; set; }
        public bool PrimaryPhoneNumbersOnly { get; set; }

        // call specific
        public Audio Audio { get; set; }
        public Audio AudioVM { get; set; }

        public int? RetryTimes { get; set; }
        public int? CallThrottle { get; set; }
        public byte MaxMessageLength { get; set; }

        // text specific
        public string TextMessage { get; set; }
        public long? TextNumberID { get; set; }

        // contains broadcast ID if combo broadcast was requested
        public long TextBroadcastID { get; set; }
    }
}
