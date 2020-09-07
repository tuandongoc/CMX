using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.Works
{
    public class CWX_AccountTicket
    {
        // Properties
        [Key]
        public int TicketID { get; set; }

        public string Description { get; set; }

        public int AccountID { get; set; }

        public int DebtorID { get; set; }

        public int TicketDefinitionID { get; set; }

        public string TicketStatus { get; set; }

        public int? IsExpired { get; set; }

        public int UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public int CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public string Status { get; set; }

        public int? AssignTo { get; set; }

        public DateTime? DueDate { get; set; }

        public int? RequireApproval { get; set; }

        public int? ReceivedApproval { get; set; }

        public int Expired { get; set; }

        public int? CompletedBy { get; set; }

        public DateTime? CompletedDate { get; set; }

        public int? CurrentLevel { get; set; }
    }
}
