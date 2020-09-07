using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.UIModels
{
    public class AccountPromiseCriteriaView
    {
        // Properties
        [Key]
        public int AccountID { get; set; }

        public decimal BillBalance { get; set; }

        public string MinPromiseAmount { get; set; }

        public string MinPromisePercent { get; set; }

        public int? MaxDaysPromiseFromToday { get; set; }
    }
}
