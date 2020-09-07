using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.Works
{
    public class AccountPromise
    {
        // Properties
        [Key]
        public int PromiseID { get; set; }

        public int AccountID { get; set; }

        public int? EmployeeID { get; set; }

        public int? Sequence { get; set; }

        public decimal? AmountPromised { get; set; }

        public DateTime? DatePromised { get; set; }

        public byte? Status { get; set; }

        public DateTime? DatePaid { get; set; }

        public decimal? AmountPaid { get; set; }

        public string Term { get; set; }

        public int? Period { get; set; }

        public int? PeriodSeq { get; set; }

        public int? PromiseFrequency { get; set; }

        public int? PromiseGiver { get; set; }

        public DateTime? DateTaken { get; set; }

        public decimal? TotalOS { get; set; }

        public decimal? MinPromiseAmt { get; set; }

        public decimal? MinPromisePer { get; set; }

        public int? PromiseIntDays { get; set; }

        public decimal? PerToKeepPromise { get; set; }

        public int? GraceDays { get; set; }

        public DateTime? DateBroken { get; set; }

        public int? Bucket { get; set; }

        public int? DPD { get; set; }

        public decimal? Rate { get; set; }

        public decimal? InterestAmount { get; set; }
    }
}
