using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.Works
{
    public class CWX_AccountTicketActivity
    {
        // Properties
        [Key]
        public int AccountTicketActivityID { get; set; }

        public int AccountTicketID { get; set; }

        public int TicketDefinitionID { get; set; }

        public int TicketActivityID { get; set; }

        public int? AttachmentID { get; set; }

        public int CurrentLevel { get; set; }

        public string Description { get; set; }

        public DateTime? DueDate { get; set; }

        public int? Expired { get; set; }

        public string ActivityStatus { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int? CompletedBy { get; set; }

        public DateTime? CompletedDate { get; set; }

        public string Status { get; set; }

        public int? AssignTo { get; set; }

        public int? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? PlanStartDate { get; set; }

        public DateTime? PlanDueDate { get; set; }
    }
}
