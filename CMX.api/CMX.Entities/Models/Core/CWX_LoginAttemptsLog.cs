using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.Core
{
    public class CWX_LoginAttemptsLog
    {
        // Properties
        [Key]
        public int LogID { get; set; }

        public DateTime? LoginDateTime { get; set; }

        public string IPAddress { get; set; }

        public string LoginStatus { get; set; }

        public string Reason { get; set; }

        public string LoginUser { get; set; }

        public int? UserID { get; set; }
    }
}
