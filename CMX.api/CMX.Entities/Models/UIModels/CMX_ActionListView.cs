using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.UIModels
{
    public class CMX_ActionListView
    {
        // Properties
        [Key]
        public long RowIndex { get; set; }

        public int ActionID { get; set; }

        public string Description { get; set; }

        public int? NextActionId { get; set; }

        public int? CallResultId { get; set; }

        public int? QueueDays { get; set; }
    }
}
