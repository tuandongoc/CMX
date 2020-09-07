using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMX.Entities.Models.POST
{
    public class AccountWorkplanListFilterByParamsRequest
    {
        // Properties
        [JsonProperty("accountId")]
        public int AccountID { get; set; }

        [JsonProperty("employeeId")]
        public int EmployeeID { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("pageIndex")]
        public int PageIndex { get; set; }
    }
}
