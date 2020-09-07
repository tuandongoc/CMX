using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.UIModels
{
    public class CMX_AccountForReviewView
    {
        // Properties
        [Key]
        public long RowNumber { get; set; }

        public string KeyField { get; set; }

        public DateTime? QueueDate { get; set; }

        public string InvoiceNumber { get; set; }

        public string Segment { get; set; }

        public string CIF { get; set; }

        public string CustomerName { get; set; }

        public int? DPD { get; set; }

        public string Bucket { get; set; }

        public string CardBucket { get; set; }

        public string Branch_Code { get; set; }

        public string Branch_Name { get; set; }

        public decimal? BillAmount { get; set; }

        public decimal? MinimumDue { get; set; }

        public decimal? PrincipleOutstanding { get; set; }

        public decimal? InterestOutstanding { get; set; }

        public decimal? OverdueInterest { get; set; }

        public decimal? OverdueCharge { get; set; }

        public string Status { get; set; }

        public int? DebtorID { get; set; }

        public int? AccountID { get; set; }

        public string Address { get; set; }

        public string Zip { get; set; }

        public decimal? BillBalance { get; set; }

        public DateTime? LastAllocationDate { get; set; }

        public int? ActionEmployee { get; set; }
    }


}
