using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.Works
{
    public class CWX_AccountTicketActivityAction
    {
        // Properties
        [Key]
        public int TicketActivityActionID { get; set; }

        public int AccountTicketID { get; set; }

        public int TicketActivityID { get; set; }

        public int AccountTicketActivityID { get; set; }

        public int Level { get; set; }

        public int PermissionType { get; set; }

        public string Action { get; set; }

        public int ActionBy { get; set; }

        public DateTime ActionDate { get; set; }

        public int ApproverID { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public string Comment { get; set; }
    }
}
