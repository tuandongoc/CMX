using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.Works
{
    public class NotesCurrent
    {
        // Properties
        [Key]
        public int NoteID { get; set; }

        public int EmployeeID { get; set; }

        public int DebtorID { get; set; }

        public int BillID { get; set; }

        public DateTime? NoteDateTime { get; set; }

        public string NoteType { get; set; }

        public string NoteText { get; set; }

        public short NotePriority { get; set; }

        public DateTime? DateForwarded { get; set; }
    }
}
