﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.UIModels
{
    public class CMX_AccountTodoListView
    {
        // Properties
        [Key]
        public long RowNumber { get; set; }

        public string KeyField { get; set; }

        public int? TicketID { get; set; }

        public int? AccountTicketActivityID { get; set; }

        public int? TicketDefinitionID { get; set; }

        public string TicketStatus { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? RequireApproval { get; set; }

        public int? ReceivedApproval { get; set; }

        public string TicketName { get; set; }

        public string ActivityName { get; set; }

        public int? ApproverID { get; set; }

        public int? OldTypeID { get; set; }

        public int? OldAssigneeID { get; set; }

        public int? NewTypeID { get; set; }

        public int? NewAssigneeID { get; set; }

        public string Creator { get; set; }

        public string AssignTo { get; set; }

        public string Priority { get; set; }

        public int? CurrentLevel { get; set; }

        public int? TotalLevel { get; set; }

        public string LastAction { get; set; }

        public DateTime? LastActionDate { get; set; }

        public int? LastActionBy { get; set; }

        public string Actitvity { get; set; }

        public DateTime? PlanStartDate { get; set; }

        public DateTime? PlanDueDate { get; set; }

        public string Address { get; set; }

        public string Zip { get; set; }

        public string CustomerName { get; set; }

        public string Source { get; set; }
    }
}
