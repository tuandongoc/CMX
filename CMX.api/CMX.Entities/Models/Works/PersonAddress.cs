using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.Works
{
    public class PersonAddress
    {
        // Properties
        [Key]
        public int AddressID { get; set; }

        public int? PersonID { get; set; }

        public byte? AddressType { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Country { get; set; }

        public string Territory { get; set; }

        public string Region { get; set; }

        public bool? MailingAddress { get; set; }

        public short AddressStatus { get; set; }

        public string Description { get; set; }

        public int? EmployeeID { get; set; }

        public DateTime? CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int? UpdateBy { get; set; }
    }
}
