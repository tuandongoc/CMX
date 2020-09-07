using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.UIModels
{
    public class CMX_AccountWorkplanView
    {
        // Properties
        [Key]
        public long RowNumber { get; set; }

        public string KeyField { get; set; }

        public int? TicketID { get; set; }

        public string TicketStatus { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? DueDate { get; set; }

        public int? RequireApproval { get; set; }

        public int? ReceivedApproval { get; set; }

        public string TicketName { get; set; }

        public string TicketCreator { get; set; }

        public string Assignee { get; set; }

        public string AssignTo { get; set; }

        public string Priority { get; set; }

        public int? CurrentLevel { get; set; }

        public int? TotalLevel { get; set; }

        public string LastAction { get; set; }

        public DateTime? LastActionDate { get; set; }

        public int? LastActionBy { get; set; }

        public string Source { get; set; }

        public int? TicketDefinitionID { get; set; }
    }
}
