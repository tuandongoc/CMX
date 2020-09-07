using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.Works
{
    public class RuleOthers
    {
        // Properties
        [Key]
        public int Id { get; set; }

        public int RuleId { get; set; }

        public int OptionType { get; set; }

        public string Value { get; set; }

        public string Value2 { get; set; }

        public string Value3 { get; set; }

        public string Value4 { get; set; }

        public string Value5 { get; set; }
    }
}
