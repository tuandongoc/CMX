using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.Works
{
    public class RuleCriteria
    {
        // Properties
        [Key]
        public int ID { get; set; }

        public int RuleID { get; set; }

        public string Description { get; set; }

        public int? DataField { get; set; }

        public string Criteria { get; set; }

        public string Operator { get; set; }

        public string Combining { get; set; }

        public string MatchingCriteria { get; set; }

        public string MatchingCriteria2 { get; set; }

        public string SQLFormat { get; set; }

        public int? OrderNumber { get; set; }

        public int? ParentID { get; set; }
    }
}
