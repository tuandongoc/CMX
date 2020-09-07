using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMX.Entities.Models.POST
{
    public class HomeActionListFilterByParamsRequest
    {
        // Properties
        [JsonProperty("employeeId")]
        public int? EmployeeID { get; set; }

        [JsonProperty("limit")]
        public int limit { get; set; }

        [JsonProperty("offset")]
        public int offset { get; set; }
    }
}
