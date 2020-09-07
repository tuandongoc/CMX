using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CMX.Entities.Models.POST
{
    public class AccountPromiseInsertRequest
    {
        // Properties
        [Required(ErrorMessage = "PromiseID is required"), JsonProperty("promiseId")]
        public int PromiseID { get; set; }

        [Required(ErrorMessage = "AccountID is required"), JsonProperty("accountId")]
        public int AccountID { get; set; }

        [JsonProperty("employeeId")]
        public int? EmployeeID { get; set; }

        [JsonProperty("sequence")]
        public int? Sequence { get; set; }

        [JsonProperty("amountPromised")]
        public decimal? AmountPromised { get; set; }

        [JsonProperty("datePromised")]
        public DateTime? DatePromised { get; set; }

        [JsonProperty("term")]
        public string Term { get; set; }

        [JsonProperty("period")]
        public int? Period { get; set; }

        [JsonProperty("periodSeq")]
        public int? PeriodSeq { get; set; }

        [JsonProperty("promiseFrequency")]
        public int? PromiseFrequency { get; set; }

        [JsonProperty("promiseGiver")]
        public int? PromiseGiver { get; set; }
    }
}
