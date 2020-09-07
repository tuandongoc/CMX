using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMX.api.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    public interface IOutstandingBalanceRepository
    {
        /// <summary>
        /// 
        /// </summary>
        object GetOutstandingBalance(string invoiceNumber);
    }
}
