using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.UIModels
{
    public class CMX_AccountPromise_GetPromiseListView
    {
        // Properties
        [Key]
        public long RowNumber { get; set; }

        public int? PromiseID { get; set; }

        public int AccountID { get; set; }

        public decimal? AmountPromised { get; set; }

        public DateTime? DatePromised { get; set; }

        public string PromiseStatus { get; set; }

        public decimal? AmountPaid { get; set; }

        public DateTime? DatePaid { get; set; }

        public int? Period { get; set; }

        public string Term { get; set; }

        public int? PromiseFrequency { get; set; }

        public decimal? Rate { get; set; }

        public decimal? InterestAmount { get; set; }

        public string EmployeeName { get; set; }

        public string PromiseGiver { get; set; }
    }
}
