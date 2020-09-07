using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMX.Entities.Models.POST
{
    public class AccountActionsOtherInsertRequest
    {
        // Properties
        [JsonProperty("actionId")]
        public int? ActionID { get; set; }

        [JsonProperty("actionType")]
        public int? ActionType { get; set; }

        [JsonProperty("completedBy")]
        public int? CompletedBy { get; set; }

        [JsonProperty("accountId")]
        public int? AccountID { get; set; }
    }
}
