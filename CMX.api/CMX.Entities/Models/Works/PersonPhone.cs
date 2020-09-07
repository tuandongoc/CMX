using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.Works
{
    public class PersonPhone
    {
        // Properties
        [Key]
        public int PhoneID { get; set; }

        public int? PersonID { get; set; }

        public byte? PhoneType { get; set; }

        public string PhoneNumber { get; set; }

        public string PhoneExtension { get; set; }

        public short PhoneStatus { get; set; }

        public string Description { get; set; }

        public int? EmployeeID { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public string PhoneTime { get; set; }

        public int? UpdateBy { get; set; }
    }
}
