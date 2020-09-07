using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMX.Entities.Models.POST
{
    public class CustomerAddressUpdateRequest
    {
        // Properties
        [JsonProperty("employeeId")]
        public int EmployeeID { get; set; }

        [JsonProperty("accountId")]
        public int AccountID { get; set; }

        [JsonProperty("address")]
        public string Address { get; set; }
    }
}
