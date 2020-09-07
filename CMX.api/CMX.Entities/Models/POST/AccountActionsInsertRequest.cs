using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMX.Entities.Models.POST
{
    public class AccountActionsInsertRequest
    {
        // Properties
        [JsonProperty("employeeId")]
        public int? EmployeeID { get; set; }

        [JsonProperty("actionId")]
        public int? ActionID { get; set; }

        [JsonProperty("accountId")]
        public int? AccountID { get; set; }

        [JsonProperty("additionalData")]
        public string AdditionalData { get; set; }
    }
}
