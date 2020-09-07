using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.POST
{
    public class NotesCurrentInsertRequest
    {
        // Properties
        [Required(ErrorMessage = "EmployeeID is required"), JsonProperty("employeeId")]
        public int EmployeeID { get; set; }

        [Required(ErrorMessage = "DebtorID is required"), JsonProperty("debtorId")]
        public int DebtorID { get; set; }

        [Required(ErrorMessage = "AccountID is required"), JsonProperty("accountId")]
        public int AccountID { get; set; }

        [JsonProperty("noteType")]
        public string NoteType { get; set; }

        [JsonProperty("noteText")]
        public string NoteText { get; set; }

        [JsonProperty("notePriority")]
        public short NotePriority { get; set; }
    }
}
