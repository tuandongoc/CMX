using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMX.Entities.Models.POST
{
    public class StatusUpdateRequest
    {
        // Properties
        [JsonProperty("accountTicketId")]
        public int AccountTicketID { get; set; }

        [JsonProperty("activityStatus")]
        public string ActivityStatus { get; set; }

        [JsonProperty("startDate")]
        public DateTime? StartDate { get; set; }

        [JsonProperty("dueDate")]
        public DateTime? DueDate { get; set; }

        [JsonProperty("updatedBy")]
        public int UpdatedBy { get; set; }

        [JsonProperty("updatedDate")]
        public DateTime UpdatedDate { get; set; }

        [JsonProperty("completedBy")]
        public int? CompletedBy { get; set; }

        [JsonProperty("completedDate")]
        public DateTime? CompletedDate { get; set; }
    }
}
