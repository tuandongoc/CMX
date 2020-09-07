using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.Works
{
    public class AccountActions
    {
        // Properties
        [Key]
        public int RecordID { get; set; }

        public int? Status { get; set; }

        public int? ResponsibleParty { get; set; }

        public DateTime? Deadline { get; set; }

        public int? ActionID { get; set; }

        public DateTime? DateCompleted { get; set; }

        public int? CompletedBy { get; set; }

        public int? AccountID { get; set; }

        public string AdditionalData { get; set; }

        public decimal? UnitCost { get; set; }
    }
}
