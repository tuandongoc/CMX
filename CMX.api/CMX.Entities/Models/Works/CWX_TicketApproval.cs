using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.Works
{
    public class CWX_TicketApproval
    {
        // Properties
        [Key]
        public int TicketApprovalID { get; set; }

        public int TicketApprovalRefID { get; set; }

        public int ApproverID { get; set; }

        public string ApprovalStatus { get; set; }

        public int ApproverLevel { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int? ActionedBy { get; set; }

        public DateTime? ActionedDate { get; set; }

        public string Location { get; set; }

        public int? PermissionType { get; set; }
    }
}
