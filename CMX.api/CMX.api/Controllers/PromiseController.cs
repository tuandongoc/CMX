using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMX.Entities.Models.POST;
using CMX.Entities.Models.UIModels;
using CMX.Entities.Models.Works;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CMX.api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PromiseController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        public PromiseController(CWorksContext context, IConfiguration configuration, ILogger<PromiseController> logger) : base(context, configuration, logger)
        {
        }


        /// <summary>
        /// FilterByAccount
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("all/{accountId}", Name = nameof(PromiseController) + nameof(FilterByAccount))]
        public async Task<IActionResult> FilterByAccount(int accountId)
        {
            try
            {
                var result = await (from ap in WorksContext.AccountPromise.Where(ap => ap.AccountID == accountId)
                                    from e in WorksContext.Employee.Where(e => e.EmployeeID == ap.EmployeeID)
                                    from acm in WorksContext.AccountCodeMaster.Where(acm => acm.CodeID == ap.PromiseGiver && acm.CodeType == 5)
                                    select new
                                    {
                                        PromiseID = ap.PromiseID,
                                        AccountID = ap.AccountID,
                                        EmployeeName = e.EmployeeName,
                                        AmountPromised = ap.AmountPromised,
                                        DatePromised = ap.DatePromised,
                                        promiseStatus = ap.Status == 0 ? "Note Due" : (ap.Status == 1 ? "Paid On Time" : (ap.Status == 2 ? "Paid Late" : (ap.Status == 3 ? "Broken Promise" : (ap.Status == 3 ? "Cancelled" : (ap.Status == 5 ? "Paid Partially" : (ap.Status == 6 ? "Paid On Time" : (ap.Status == 7 ? "Disapprove" : "-"))))))),
                                        AmountPaid = ap.AmountPaid,
                                        DatePaid = ap.DatePaid,
                                        PromiseGiver = acm.CodeDesc
                                    }
                              ).AsNoTracking().ToListAsync();

                if (result.Any())
                {
                    // status code = 200
                    return new ObjectResult(result);
                }
                else
                {
                    // status code = 404
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex, nameof(PromiseController) + "-" + nameof(FilterByAccount), LogLevel.Error, false);
                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// FilterInfoTable
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("frequency", Name = nameof(PromiseController) + nameof(FilterInfoTable))]
        public async Task<IActionResult> FilterInfoTable(int accountId)
        {
            try
            {
                var result = await (from ib in WorksContext.InformationTable.Where(ib => ib.InfoID == 4
                                    && ib.InfoType == 1
                                    && ib.InfoSubType == 0
                                    && ib.Status != "R")
                                    select new
                                    {
                                        InfoKey = ib.InfoKey,
                                        Description = ib.Description,
                                        Value = ib.Value
                                    }
                              ).AsNoTracking().ToListAsync();

                if (result.Any())
                {
                    // status code = 200
                    return new ObjectResult(result);
                }
                else
                {
                    // status code = 404
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex, nameof(PromiseController) + "-" + nameof(FilterInfoTable), LogLevel.Error, false);
                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetLastestPromiseId
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("get-lastest-id", Name = nameof(PromiseController) + nameof(GetLastestPromiseId))]
        public async Task<IActionResult> GetLastestPromiseId()
        {
            try
            {
                var result = await (from a in WorksContext.AccountPromise
                                    select new
                                    {
                                        PromiseID = a.PromiseID
                                    }
                                ).AsNoTracking().ToListAsync();

                if (result.Count < 1)
                {
                    var _result = new List<AccountPromiseMaxIdView>
                    {
                        new AccountPromiseMaxIdView { PromiseID  = 1}
                    };

                    return new ObjectResult(_result);
                }
                else
                {
                    List<int> iResult = new List<int>();
                    foreach (var item in result)
                    {
                        iResult.Add(item.PromiseID);
                    }

                    int maxNumber = iResult.Max();
                    var _result = new List<AccountPromiseMaxIdView>
                    {
                        new AccountPromiseMaxIdView { PromiseID  = maxNumber + 1}
                    };
                    return new ObjectResult(_result);
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex, nameof(PromiseController) + "-" + nameof(GetLastestPromiseId), LogLevel.Error, false);
                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// Get all promise criteria by accountId
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("criteria/{accountId}", Name = nameof(PromiseController) + nameof(GetPromiseCriteriaByAccountId))]
        public async Task<IActionResult> GetPromiseCriteriaByAccountId(int accountId)
        {
            try
            {
                string strQuery = @"SELECT AccountID, BillBalance, [dbo].[CWX_Get_SystemWideDefault](AccountID,5) AS MinPromiseAmount, [dbo].[CWX_Get_SystemWideDefault](AccountID,6) AS MinPromisePercent, 
                                    CAST([dbo].[CWX_Get_SystemWideDefault](AccountID,10) AS int) AS MaxDaysPromiseFromToday
                                    FROM Account";
                var result = await WorksContext.AccountPromiseCriteriaView.FromSql(strQuery)
                    .Where(a => a.AccountID == accountId)
                    .Select(a => new
                    {
                        AccountID = a.AccountID,
                        BillBalance = a.BillBalance,
                        MinPromiseAmount = a.MinPromiseAmount,
                        MinPromisePercent = a.MinPromisePercent,
                        //MinPromiseAmountPercent = a.MinPromiseAmountPercent,
                        MaxDaysPromiseFromToday = a.MaxDaysPromiseFromToday
                    }).AsNoTracking().ToListAsync();

                if (result.Any())
                {
                    // status code = 200
                    return new ObjectResult(result);
                }
                else
                {
                    // status code = 404
                    return NotFound();
                }
            }
            catch (Exception)
            {
                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="201">Created</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Have Error</response>
        [HttpPost("insert", Name = nameof(PromiseController) + nameof(Insert))]
        public async Task<IActionResult> Insert([FromBody]AccountPromiseInsertRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                var accPromise = await WorksContext.AccountPromise.Where(c => c.PromiseID == request.PromiseID).FirstOrDefaultAsync();
                if(accPromise != null)
                {
                    //status code 400
                    return BadRequest("PromiseID: " + request.PromiseID + " exists already");
                }

                AccountPromise accountPromise = new AccountPromise();
                accountPromise.PromiseID = request.PromiseID;
                accountPromise.AccountID = request.AccountID;
                accountPromise.EmployeeID = request.EmployeeID;
                accountPromise.Sequence = request.Sequence;
                accountPromise.AmountPromised = request.AmountPromised;
                accountPromise.DatePromised = request.DatePromised;
                accountPromise.Status = 0;
                accountPromise.DatePaid = DateTime.MinValue;
                accountPromise.AmountPaid = 0;
                accountPromise.Term = request.Term.Substring(0,1);
                accountPromise.Period = request.Period;
                accountPromise.PeriodSeq = request.PeriodSeq;
                accountPromise.PromiseFrequency = request.PromiseFrequency;
                accountPromise.PromiseGiver = request.PromiseGiver;
                accountPromise.DateTaken = DateTime.Now;

                WorksContext.AccountPromise.Add(accountPromise);
                await WorksContext.SaveChangesAsync();

                return new ObjectResult(accountPromise);
            }
            catch (Exception ex)
            {
                WriteLog(ex, nameof(PromiseController) + "-" + nameof(Insert), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// PromiseFilterByAccount
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Have Error</response>
        [HttpPost("all/filter", Name = nameof(PromiseController) + nameof(PromiseFilterByAccount))]
        public async Task<IActionResult> PromiseFilterByAccount([FromBody] PromiseFilterByAccountRequest request)
        {
            try
            {
                List<CMX_AccountPromise_GetPromiseListView> listData = new List<CMX_AccountPromise_GetPromiseListView>();
                string strSQL = @"exec CMX_AccountPromise_GetPromiseList @AccountID=";
                strSQL = strSQL + request.AccountID.ToString();
                if (request.PageSize <= 0)
                {
                    strSQL = strSQL + ", @PageSize=40, @PageIndex=0";
                }
                else
                {
                    strSQL = strSQL + @", @PageSize = ";
                    strSQL = strSQL + request.PageSize.ToString();
                    strSQL = strSQL + @", @PageIndex=";
                    strSQL = strSQL + request.PageIndex.ToString();
                }
                listData = await WorksContext.CMX_AccountPromise_GetPromiseListView.FromSql(strSQL).ToListAsync();

                if (listData.Any())
                {
                    // status code = 200
                    return new ObjectResult(listData);
                }
                else
                {
                    // status code = 404
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex, nameof(PromiseController) + "-" + nameof(PromiseFilterByAccount), LogLevel.Error, false);
                // status code = 400
                return BadRequest();
                throw;
            }
        }
    }
}