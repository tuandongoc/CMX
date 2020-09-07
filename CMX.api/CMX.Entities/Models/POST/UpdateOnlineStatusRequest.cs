using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMX.Entities.Models.POST
{
    public class UpdateOnlineStatusRequest
    {
        // Properties
        [JsonProperty("username")]
        public string Username { get; set; }
    }
}
