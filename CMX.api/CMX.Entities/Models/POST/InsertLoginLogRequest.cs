using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMX.Entities.Models.POST
{
    public class InsertLoginLogRequest
    {
        // Properties
        [JsonProperty("userID")]
        public int UserID { get; set; }

        [JsonProperty("loginTime")]
        public DateTime LoginTime { get; set; }
    }
}
