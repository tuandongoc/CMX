using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.Works
{
    public class Employee
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

        public string State { get; set; }

        public string Zip { get; set; }

        public string UserID { get; set; }

        public string Description { get; set; }

        public double? PayDraw { get; set; }

        public float PayNormalPercent { get; set; }

        public float PayOCPercent { get; set; }

        public short NormalPercAfterDayx { get; set; }

        public bool Supervisor { get; set; }

        public short? MaxNoPromise { get; set; }

        public short? MaxWithProm { get; set; }

        public string Extension { get; set; }

        public bool AutoAssign { get; set; }

        public decimal MimDailyAmt { get; set; }

        public string AssColStart { get; set; }

        public string AssColEnd { get; set; }

        public decimal Goal { get; set; }

        public int? SuperVisorId { get; set; }

        public string Nationality { get; set; }

        public string Language_Id { get; set; }

        public int? Prior_Exp { get; set; }

        public DateTime? Date_Of_Joining { get; set; }

        public int? Daily_Cap { get; set; }

        public string Comment1 { get; set; }

        public string Comment2 { get; set; }

        public string Comment3 { get; set; }

        public bool? SignOn { get; set; }

        public bool? Blocked { get; set; }

        public int? Department { get; set; }

        public int? RoleID { get; set; }

        public string EmployeeStatus { get; set; }

        public int? PoolRight { get; set; }

        public string EmployeeType { get; set; }

        public DateTime? CreatedDate { get; set; }

        public int? GoalCount { get; set; }

        public string CheckerStatus { get; set; }

        public string EmailAddress { get; set; }

        public string IDNum { get; set; }

        public string MobilePhone { get; set; }

        public string Education { get; set; }

        public int? TeamID { get; set; }

        public int? BranchID { get; set; }

        public int? AreaID { get; set; }

        public int? RegionID { get; set; }

        public string Bucket { get; set; }

        public DateTime? ResignDate { get; set; }

        public string ResignReason { get; set; }

        public DateTime? UserAccessExpiration { get; set; }

        public DateTime? BlacklistDate { get; set; }

        public string EmergencyName { get; set; }

        public string EmergencyAddress { get; set; }

        public string EmergencyStreet { get; set; }

        public string EmergencyCity { get; set; }

        public string EmergencyState { get; set; }

        public string EmergencyZip { get; set; }

        public string EmergencyPhone { get; set; }

        public string EmergencyExtension { get; set; }

        public string EmergencyMobilePhone { get; set; }

        public string EmergencyEmail { get; set; }

        public int? SearchRestriction { get; set; }

        public int? EmployeeSearchRestriction { get; set; }

        public int DelegatedUser { get; set; }

        public int PoolReQueuingType { get; set; }

        public bool? AllocateOnLeave { get; set; }

        public bool? ReAllocateOnLeave { get; set; }

        public int? MobileCommunicationPreference { get; set; }
    }
}
