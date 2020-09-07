using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMX.Entities.Models.POST
{
    public class NotesFilterByParamsRequest
    {
        // Properties
        [JsonProperty("accountId")]
        public int? AccountID { get; set; }

        [JsonProperty("debtorId")]
        public int? DebtorID { get; set; }

        [JsonProperty("noteText")]
        public string NoteText { get; set; }

        [JsonProperty("noteType")]
        public string NoteType { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }

        [JsonProperty("pageIndex")]
        public int PageIndex { get; set; }
    }
}
