using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMX.Entities.Models.POST
{
    public class AccountCollateralGetListRequest
    {
        // Properties
        [JsonProperty("accountID")]
        public int? AccountID { get; set; }
    }


}
