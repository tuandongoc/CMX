using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.UIModels
{
    public class CMX_NotesSearchView
    {
        // Properties
        [Key]
        public long RowNumber { get; set; }

        public DateTime? NoteDateTime { get; set; }

        public string NoteText { get; set; }

        public string NoteType { get; set; }

        public string EmployeeName { get; set; }

        public int? BillID { get; set; }

        public int? DebtorID { get; set; }

        public string InvoiceNumber { get; set; }

        public short? NotePriority { get; set; }

        public int? NoteID { get; set; }
    }
}
