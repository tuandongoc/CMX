using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.Works
{
    public class ClientInformation
    {
        // Properties
        [Key]
        public int ClientID { get; set; }

        public string ClientName { get; set; }

        public int? Priority { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Country { get; set; }

        public string Region { get; set; }

        public string Territory { get; set; }

        public string PhoneNumber { get; set; }

        public string FaxNumber { get; set; }

        public string ContactName { get; set; }

        public string ContactExtension { get; set; }

        public string EMail { get; set; }

        public DateTime? FirstReferralDate { get; set; }

        public DateTime? LastReferralDate { get; set; }

        public int? AccountTypeID { get; set; }

        public byte? GrossClientFlag { get; set; }

        public bool ReportDebtorsFlag { get; set; }

        public bool DeductARBalanceFlag { get; set; }

        public bool ChargeInterestFlag { get; set; }

        public bool ReceivedStatement { get; set; }

        public decimal? MinimumBalanceToReport { get; set; }

        public decimal? PreviousARBalance { get; set; }

        public decimal? PreviousAPBalance { get; set; }

        public float? ClientPercent { get; set; }

        public float? ClientOCPercent { get; set; }

        public float? ClientLegalPercent { get; set; }

        public short? AcknowledgmentReport { get; set; }

        public short? InventoryReport { get; set; }

        public short? StatementReport { get; set; }

        public short? HistoryReport { get; set; }

        public int? SalesmanID { get; set; }

        public float? SalesmanPercentage { get; set; }

        public byte? ClientPayCycle { get; set; }

        public int? MasterClient { get; set; }

        public bool Referral { get; set; }

        public bool Active { get; set; }

        public decimal? AgingForReschedule { get; set; }

        public decimal? AgingForDiscount { get; set; }

        public int? RescheduleAllowed { get; set; }

        public int? DiscountAllowed { get; set; }

        public string DeptIDs { get; set; }

        public byte[] LetterheadImage { get; set; }

        public string Status { get; set; }

        public int? CreditorID { get; set; }

        public int? PaymentAllocationRuleID { get; set; }

        public decimal? AgingForApportion { get; set; }

        public int? ApportionAllowed { get; set; }

        public decimal? Goal { get; set; }

        public int? GoalCount { get; set; }

        public int? GroupID { get; set; }
    }
}
