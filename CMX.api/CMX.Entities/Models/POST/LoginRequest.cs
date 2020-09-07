using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMX.Entities.Models.POST
{
    public class LoginRequest
    {
        // Properties
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}
