using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.Works
{
    public class RuleTable
    {
        // Properties
        [Key]
        public int ID { get; set; }

        public byte RuleType { get; set; }

        public string Description { get; set; }

        public int InterfaceID { get; set; }

        public int? Priority { get; set; }

        public int? Fax { get; set; }

        public int? AllocationRuleID { get; set; }

        public int? MaintainOfficer { get; set; }

        public string Category { get; set; }

        public string CheckerStatus { get; set; }

        public string Status { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? DateCreated { get; set; }

        public int? ModifiedBy { get; set; }

        public DateTime? DateModified { get; set; }

        public int? AssignmentType { get; set; }

        public int? AllocationMethod { get; set; }

        public int? AssignmentSegment { get; set; }

        public DateTime? AssignmentStartDate { get; set; }

        public DateTime? AssignmentEndDate { get; set; }

        public bool? ForceReallocation { get; set; }

        public int? AssignmentDurationType { get; set; }

        public int? AssignmentDurationSpan { get; set; }

        public int? AssigneeType { get; set; }

        public string ExecutionStatus { get; set; }

        public int? RuleMasterID { get; set; }

        public decimal? ChampionPercentage { get; set; }

        public int? RuleSuccessFactorID { get; set; }

        public DateTime? EffectiveStartDate { get; set; }

        public DateTime? EffectiveEndDate { get; set; }

        public int? UpdatedID { get; set; }
    }
}
