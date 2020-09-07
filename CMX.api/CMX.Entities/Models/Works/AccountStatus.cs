using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.Works
{
    public class AccountStatus
    {
        // Properties
        [Key]
        public int AgencyStatus { get; set; }

        public string ShortDesc { get; set; }

        public string LongDesc { get; set; }

        public int SystemStatus { get; set; }

        public bool SupReq { get; set; }

        public bool AcceptPartPay { get; set; }

        public bool ReportToCreditBureau { get; set; }

        public byte PIF_Status { get; set; }

        public bool LettersAllowed { get; set; }

        public bool LoadInDialer { get; set; }

        public bool PrintOnReports { get; set; }

        public bool LoadInQueue { get; set; }

        public bool CalcInBalance { get; set; }

        public bool ChargeInterest { get; set; }

        public bool OverrideDateAdvancement { get; set; }

        public bool SpecialProcessingStatus { get; set; }

        public byte? CreditReportAction { get; set; }

        public int? SortPriority { get; set; }

        public string Status { get; set; }

        public int? LoadInProductID { get; set; }

        public string Type { get; set; }
    }
}
