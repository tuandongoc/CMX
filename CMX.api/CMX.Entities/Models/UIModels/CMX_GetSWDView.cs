using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.UIModels
{
    public class CMX_GetSWDView
    {
        // Properties
        [Key]
        public long RowIndex { get; set; }

        public int AccountID { get; set; }

        public string SWD_Value { get; set; }
    }
}
