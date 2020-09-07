using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMX.Entities.Models.POST
{
    public class CWXAccountTicketActivityActionInsertRequest
    {
        // Properties
        [JsonProperty("accountTicketId")]
        public int AccountTicketID { get; set; }

        [JsonProperty("accountTicketActivityId")]
        public int AccountTicketActivityID { get; set; }

        [JsonProperty("employeeId")]
        public int EmployeeID { get; set; }

        [JsonProperty("comment")]
        public string Comment { get; set; }
    }
}
