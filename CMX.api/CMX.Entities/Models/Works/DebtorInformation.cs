using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.Works
{
    public class DebtorInformation
    {
        // Properties
        [Key]
        public int DebtorID { get; set; }

        public int PersonID { get; set; }

        public string CompanyName { get; set; }

        public string DoingBusinessAs { get; set; }

        public string GroupName { get; set; }

        public string HotNote { get; set; }

        public string ZipDelPoint { get; set; }

        public string ZipCart { get; set; }

        public bool ReturnedMail { get; set; }

        public bool HoldLetters { get; set; }

        public bool HoldHomeCalls { get; set; }

        public bool HoldWorkCalls { get; set; }

        public bool PullCreditReport { get; set; }

        public bool SendReminderLetters { get; set; }

        public string DateOfLastCreditReportPull { get; set; }

        public string CreditReportFileName { get; set; }

        public DateTime? LastEditDate { get; set; }

        public int? LastEditBy { get; set; }

        public int? LockedByID { get; set; }

        public string LockedBy { get; set; }

        public DateTime? LockedDate { get; set; }
    }
}
