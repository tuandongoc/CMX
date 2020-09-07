using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.UIModels
{
    public class CMX_AccountCollateral_GetListView
    {
        // Properties
        [Key]
        public long RowIndex { get; set; }

        public string CString1 { get; set; }

        public string CString2 { get; set; }

        public int ID { get; set; }
    }


}
