using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMX.Entities.Models.POST
{
    public class AccountUpdateRequest
    {
        // Properties
        [JsonProperty("accountId")]
        public int AccountID { get; set; }

        [JsonProperty("queueDate")]
        public DateTime? QueueDate { get; set; }

        [JsonProperty("currentAction")]
        public byte? CurrentAction { get; set; }

        [JsonProperty("currentNextAction")]
        public int? CurrentNextAction { get; set; }

        [JsonProperty("agencyStatusId")]
        public int? AgencyStatusID { get; set; }

        [JsonProperty("systemStatusId")]
        public int? SystemStatusID { get; set; }

        [JsonProperty("actionEmployee")]
        public int? ActionEmployee { get; set; }
    }
}
