using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.Works
{
    public class AvailableActions
    {
        // Properties
        [Key]
        public int ActionID { get; set; }

        public string Description { get; set; }

        public bool? ConsiderWorked { get; set; }

        public string ActionType { get; set; }

        public bool? IncludeOnReport { get; set; }

        public int? Category { get; set; }

        public string ResultType { get; set; }

        public int? ProductivityID { get; set; }

        public decimal? UnitCost { get; set; }

        public int? CallResultId { get; set; }

        public int? NextActionId { get; set; }

        public int? QueueDays { get; set; }

        public string Status { get; set; }

        public int? LoadInProductID { get; set; }

        public int? ActionSubtypeID { get; set; }

        public int? AssignmentSegment { get; set; }
    }
}
