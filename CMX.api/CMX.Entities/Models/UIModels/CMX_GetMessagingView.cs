using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.UIModels
{
    public class CMX_GetMessagingView
    {
        // Properties
        [Key]
        public long RowNumber { get; set; }

        public int ID { get; set; }

        public int? ToEmployee { get; set; }

        public int? FromEmployee { get; set; }

        public string FromName { get; set; }

        public int? DebtorID { get; set; }

        public int? AccountID { get; set; }

        public DateTime? DisplayOn { get; set; }

        public string Message { get; set; }

        public DateTime? EntryDate { get; set; }

        public bool? Active { get; set; }

        public bool? EmployeeRead { get; set; }

        public string Status { get; set; }

        public string MessageType { get; set; }
    }
}
