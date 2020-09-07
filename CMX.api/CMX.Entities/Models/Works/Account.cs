using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.Works
{
    public class Account
    {
        // Properties
        [Key]
        public int AccountID { get; set; }

        public int DebtorID { get; set; }

        public int? EmployeeID { get; set; }

        public int? ClientID { get; set; }

        public int? AgencyStatusID { get; set; }

        public int? SystemStatusID { get; set; }

        public byte? ActionCodeID { get; set; }

        public short? OfficeID { get; set; }

        public short? MCode { get; set; }

        public short? CCode { get; set; }

        public string InvoiceNumber { get; set; }

        public string AccountType { get; set; }

        public string AccountClass { get; set; }

        public DateTime? QueueDate { get; set; }

        public DateTime? DateOfService { get; set; }

        public DateTime? SubmissionDate { get; set; }

        public DateTime? LastClientTransactionDate { get; set; }

        public decimal RoutinePayment { get; set; }

        public byte? PaymentPlan { get; set; }

        public string PatientName { get; set; }

        public decimal BillAmount { get; set; }

        public decimal BillBalance { get; set; }

        public decimal BillOtherCharges { get; set; }

        public bool ClientPaysLegalFees { get; set; }

        public bool AccountForwarded { get; set; }

        public bool CreditReported { get; set; }

        public DateTime? CreditReportedDate { get; set; }

        public float ClientPercent { get; set; }

        public float ClientOCPercent { get; set; }

        public bool SplitPayment { get; set; }

        public byte? CurrentAction { get; set; }

        public DateTime? CurrentActionDate { get; set; }

        public DateTime? NoLetterBefore { get; set; }

        public DateTime? NoFeeBefore { get; set; }

        public bool MaintainOfficer { get; set; }

        public int AccountAge { get; set; }

        public DateTime LastEditDate { get; set; }

        public string LastEditBy { get; set; }

        public DateTime? LastVerifyDate { get; set; }

        public int? AllocRuleID { get; set; }

        public int? AutoProcRuleID { get; set; }

        public DateTime? LastExtractionDate { get; set; }

        public DateTime? LastAllocationDate { get; set; }

        public DateTime? LastAutoProcessDate { get; set; }

        public int? ExtractionRuleID { get; set; }

        public int? AccountForwardedTo { get; set; }

        public string CurrencyCode { get; set; }

        public string BatchNumber { get; set; }

        public float? InterestRate { get; set; }

        public int? ActionEmployee { get; set; }

        public string LastPromiseBatch { get; set; }

        public bool? CreditReportRequested { get; set; }

        public int? CreditReportRequestedBy { get; set; }

        public DateTime? CreditReportRequestedOn { get; set; }

        public int? CreditReportRequestStatus { get; set; }

        public DateTime? WriteOffDate { get; set; }

        public DateTime? LastInterestDate { get; set; }

        public int? TempEmployeeID { get; set; }

        public bool OAManaged { get; set; }

        public int? InterfaceID { get; set; }

        public string Delq_string { get; set; }

        public int? SortOrder { get; set; }

        public bool? Allocated { get; set; }

        public int? BrokenCount { get; set; }

        public string CARD_FILE_NO { get; set; }

        public string ARREAR_PATH { get; set; }

        public string BUCKET_TYPE { get; set; }

        public string OLD_BUCKET_TYPE { get; set; }

        public string CARD_TYPE { get; set; }

        public string BRANCH_CODE { get; set; }

        public string FORMULA { get; set; }

        public string BANK_CODE { get; set; }

        public string PAID { get; set; }

        public string OtherAccountNo { get; set; }

        public string TENOR { get; set; }

        public string FORMULA_FLAG { get; set; }

        public decimal? MINIMUM_DUE { get; set; }

        public decimal? CURRENT_BKT_NUM { get; set; }

        public decimal? PREV_BKT_NUM { get; set; }

        public int? productivecount { get; set; }

        public int? contactcount { get; set; }

        public int? nocontactcount { get; set; }

        public string DelqHistory { get; set; }

        public int? BucketMovement { get; set; }

        public int? DPDMovement { get; set; }

        public int? PreviousAllocRuleID { get; set; }

        public int? OnLeaveEmpID { get; set; }

        public string LeaveLoadRelFlag { get; set; }

        public int? CurrentReason { get; set; }

        public DateTime? CurrentReasonDate { get; set; }

        public int? CurrentNextAction { get; set; }

        public DateTime? CurrentNextActionDate { get; set; }

        public int? CurrentCallResult { get; set; }

        public DateTime? CurrentCallResultDate { get; set; }

        public int? CampaignId { get; set; }

        public DateTime? CloseDate { get; set; }

        public int? MaxContact { get; set; }

        public string AssignmentType { get; set; }

        public bool? PoolSelected { get; set; }

        public bool? IsPending { get; set; }

        public int? GroupID { get; set; }

        public int? AgencyID { get; set; }

        public bool? IsGroupAccount { get; set; }

        public int? AssignmentSegment { get; set; }

        public DateTime? AssignmentStartDate { get; set; }

        public DateTime? AssignmentEndDate { get; set; }

        public DateTime? TempAssignmentEndDate { get; set; }

        public DateTime? PoolAccessDate { get; set; }

        public int? PoolAccessBy { get; set; }
    }
}
