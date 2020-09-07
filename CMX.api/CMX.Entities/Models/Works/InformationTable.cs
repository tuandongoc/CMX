using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.Works
{
    public class InformationTable
    {
        // Properties
        [Key]
        public int InfoID { get; set; }

        public byte InfoType { get; set; }

        public byte InfoSubType { get; set; }

        public string InfoKey { get; set; }

        public string Description { get; set; }

        public string Value { get; set; }

        public string ValueFormat { get; set; }

        public string Status { get; set; }
    }
}
