using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.Works
{
    public class AccountActionsOther
    {
        // Properties
        [Key]
        public int RecordID { get; set; }

        public int? ActionID { get; set; }

        public int? ActionType { get; set; }

        public DateTime? ActionDate { get; set; }

        public int? CompletedBy { get; set; }

        public int? AccountID { get; set; }
    }
}
