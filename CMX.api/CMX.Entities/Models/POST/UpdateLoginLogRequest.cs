using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMX.Entities.Models.POST
{
    public class UpdateLoginLogRequest
    {
        // Properties
        [JsonProperty("userID")]
        public int UserID { get; set; }

        [JsonProperty("loginTime")]
        public DateTime LoginTime { get; set; }

        [JsonProperty("minutesLoggedIn")]
        public int MinutesLoggedIn { get; set; }
    }
}
