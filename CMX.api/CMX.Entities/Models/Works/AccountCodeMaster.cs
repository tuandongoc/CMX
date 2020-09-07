using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.Works
{
    public class AccountCodeMaster
    {
        // Properties
        [Key]
        public int CodeID { get; set; }

        public int CodeType { get; set; }

        public string CodeDesc { get; set; }

        public int? HostID { get; set; }

        public string Status { get; set; }
    }
}
