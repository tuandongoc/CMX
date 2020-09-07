using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class AccountController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        public AccountController(CWorksContext context, IConfiguration configuration, ILogger<AccountController> logger) : base(context, configuration, logger)
        {
        }

        /// <summary>
        /// GetAccountById
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("{accountId}", Name = "account-detail")]
        public async Task<IActionResult> GetAccountById(int accountId)
        {
            try
            {
                var result = await (from a in WorksContext.Account.Where(a => a.AccountID == accountId)
                                    from d in WorksContext.DebtorInformation.Where(d => d.DebtorID == a.DebtorID)
                                    from p in WorksContext.PersonInformation.Where(p => p.PersonID == d.PersonID)
                                    from pa in WorksContext.PersonAddress.Where(pa => pa.PersonID == d.PersonID && pa.MailingAddress == true)
                                    from pp in WorksContext.PersonPhone.Where(pp => pp.PersonID == d.PersonID && pp.PhoneType == 2)
                                    from c in WorksContext.ClientInformation.Where(c => c.ClientID == a.ClientID).DefaultIfEmpty()
                                    from s in WorksContext.AccountStatus.Where(s => s.AgencyStatus == a.AgencyStatusID).DefaultIfEmpty()
                                    select new
                                    {
                                        DebtorID = a.DebtorID,
                                        AccountID = a.AccountID,
                                        InvoiceNumber = a.InvoiceNumber,
                                        customerName = p.FirstName + " " + p.MiddleName + " " + p.LastName,
                                        Product = c.ClientName,
                                        mobilePhone = pp.PhoneNumber,
                                        Address = new
                                        {
                                            Address1 = pa.Address1,
                                            Address2 = pa.Address2,
                                            Address3 = pa.Address3,
                                        },
                                        Zip = pa.Zip,
                                        City = pa.City,
                                        Country = pa.Country,
                                        Status = s.LongDesc,
                                        BillAmount = a.BillAmount,
                                        BillBalance = a.BillBalance,
                                        AccountAge = a.AccountAge,
                                        MCode = a.MCode,
                                        CCode = a.CCode,
                                        QueueDate = a.QueueDate,
                                        LastAllocationDate = a.LastAllocationDate,
                                        ActionEmployee = a.ActionEmployee,
                                        BranchCode = a.BRANCH_CODE,
                                        AssignmentStartDate = a.AssignmentStartDate,
                                        AssignmentEndDate = a.AssignmentEndDate,
                                        AssignmentSegment = a.AssignmentSegment
                                    }
                                ).FirstOrDefaultAsync();

                if (result != null)
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
                WriteLog(ex, nameof(AccountController) + "-" + nameof(GetAccountById), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetAccountForReview
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("review/{employeeId}/{nextActionId}/{pageSize}/{pageIndex}", Name = nameof(AccountController) + nameof(GetAccountForReview))]
        public async Task<IActionResult> GetAccountForReview(int employeeId, int nextActionId = 0, int pageSize = 0, int pageIndex = 0)
        {
            try
            {
                List<CMX_AccountForReviewView> listData = new List<CMX_AccountForReviewView>();
                string strSQL = "";
                if (pageSize <= 0)
                {
                    strSQL = @"EXEC CMX_AccountForReview @v_EmployeeId=";
                    strSQL = strSQL + employeeId.ToString();
                    strSQL = strSQL + @", @NextActionID=";
                    strSQL = strSQL + nextActionId.ToString();
                    strSQL = strSQL + @", @PageSize=40, @PageIndex=0";
                }
                else
                {
                    strSQL = @"EXEC CMX_AccountForReview @v_EmployeeId=";
                    strSQL = strSQL + employeeId.ToString();
                    strSQL = strSQL + @", @NextActionID=";
                    strSQL = strSQL + nextActionId.ToString();
                    strSQL = strSQL + @", @PageSize=";
                    strSQL = strSQL + pageSize.ToString();
                    strSQL = strSQL + @", @PageIndex=";
                    strSQL = strSQL + pageIndex.ToString();
                }
                listData = await WorksContext.CMX_AccountForReviewView.FromSql(strSQL).ToListAsync();

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
                WriteLog(ex, nameof(AccountController) + "-" + nameof(GetAccountForReview), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetAccountList
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("all", Name = nameof(AccountController) + nameof(GetAccountList))]
        public async Task<IActionResult> GetAccountList()
        {
            try
            {
                var result = await (from a in WorksContext.Account
                                    from d in WorksContext.DebtorInformation.Where(d => d.DebtorID == a.DebtorID)
                                    from p in WorksContext.PersonInformation.Where(p => p.PersonID == d.PersonID)
                                    from pa in WorksContext.PersonAddress.Where(pa => pa.PersonID == d.PersonID && pa.MailingAddress == true)
                                    from pp in WorksContext.PersonPhone.Where(pp => pp.PersonID == d.PersonID && pp.PhoneType == 2)
                                    from c in WorksContext.ClientInformation.Where(c => c.ClientID == a.ClientID).DefaultIfEmpty()
                                    from s in WorksContext.AccountStatus.Where(s => s.AgencyStatus == a.AgencyStatusID).DefaultIfEmpty()
                                    select new
                                    {
                                        DebtorID = a.DebtorID,
                                        AccountID = a.AccountID,
                                        InvoiceNumber = a.InvoiceNumber,
                                        customerName = p.FirstName + " " + p.MiddleName + " " + p.LastName,
                                        Product = c.ClientName,
                                        mobilePhone = pp.PhoneNumber,
                                        Address = new
                                        {
                                            Address1 = pa.Address1,
                                            Address2 = pa.Address2,
                                            Address3 = pa.Address3,
                                        },
                                        Zip = pa.Zip,
                                        City = pa.City,
                                        Country = pa.Country,
                                        Status = s.LongDesc,
                                        BillAmount = a.BillAmount,
                                        BillBalance = a.BillBalance,
                                        AccountAge = a.AccountAge,
                                        MCode = a.MCode,
                                        CCode = a.CCode,
                                        QueueDate = a.QueueDate,
                                        LastAllocationDate = a.LastAllocationDate,
                                        ActionEmployee = a.ActionEmployee,
                                        BranchCode = a.BRANCH_CODE,
                                        AssignmentStartDate = a.AssignmentStartDate,
                                        AssignmentEndDate = a.AssignmentEndDate,
                                        AssignmentSegment = a.AssignmentSegment
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
                WriteLog(ex, nameof(AccountController) + "-" + nameof(GetAccountList), LogLevel.Error, false);
                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetAccountSWD
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("{accountId}/{settingId}", Name = nameof(AccountController) + nameof(GetAccountSWD))]
        public async Task<IActionResult> GetAccountSWD(int accountId, int settingId)
        {
            try
            {
                List<CMX_GetSWDView> listData = new List<CMX_GetSWDView>();
                string strSQL = "";
                strSQL = @"EXEC CMX_GetSWD @AccountID=";
                strSQL = strSQL + accountId.ToString();
                strSQL = strSQL + @", @SettingID=";
                strSQL = strSQL + settingId.ToString();
                listData = await WorksContext.CMX_GetSWDView.FromSql(strSQL).ToListAsync();

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
                WriteLog(ex, nameof(AccountController) + "-" + nameof(GetAccountSWD), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }
    }
}