using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMX.Entities.Models.POST
{
    public class InsertLogAttemptRequest
    {
        // Properties
        [JsonProperty("loginUser")]
        public string LoginUser { get; set; }

        [JsonProperty("ipAddress")]
        public string IPAddress { get; set; }

        [JsonProperty("loginStatus")]
        public string LoginStatus { get; set; }

        [JsonProperty("reason")]
        public string Reason { get; set; }
    }
}
