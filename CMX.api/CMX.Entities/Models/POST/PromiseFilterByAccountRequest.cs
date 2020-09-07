using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMX.Entities.Models.POST
{
    public class PromiseFilterByAccountRequest
    {
        // Properties
        [JsonProperty("accountId")]
        public int? AccountID { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("pageIndex")]
        public int PageIndex { get; set; }
    }
}
