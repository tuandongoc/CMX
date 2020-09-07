using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.UIModels
{
    public class CMX_LoginView
    {
        // Properties
        [Key]
        public int EmployeeID { get; set; }

        public string EmployeeName { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public int? SupervisorID { get; set; }

        public string UserID { get; set; }

        public string Description { get; set; }

        public string EmailAddress { get; set; }

        public string TeamName { get; set; }

        public int? RegionID { get; set; }

        public string DeptDesc { get; set; }

        public string AreaName { get; set; }

        public string BranchName { get; set; }

        //public int? RoleID { get; set; }

        //public string RoleName { get; set; }

        //public DateTime? LoginTime { get; set; }

        //public string MessageEN { get; set; }

        //public string MessageVI { get; set; }

        //public bool Supervisor { get; set; }
    }


}
