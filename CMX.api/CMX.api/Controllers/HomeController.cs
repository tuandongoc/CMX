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
    public class HomeController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        public HomeController(CWorksContext context, IConfiguration configuration, ILogger<HomeController> logger) : base(context, configuration, logger)
        {
        }

        /// <summary>
        /// FilterAccountListByParams
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="500">Have Error</response>
        [HttpPost("account-list/filter", Name = nameof(HomeController) + nameof(FilterAccountListByParams))]
        public async Task<IActionResult> FilterAccountListByParams([FromBody]HomeAccountListFilterByParamsRequest request)
        {
            try
            {
                List<CMX_AccountListView> listData = new List<CMX_AccountListView>();
                string query = "";
                if (request.PageSize <= 0)
                {
                    query = @"exec [CMX_AccountList] @v_employeeId=" + request.EmployeeID.ToString() + ", @v_SystemStatus=0, @AccountAge=-1, @MCode=-1, @CCode=-1, @PageSize=40, @PageIndex=0";
                }
                else
                {
                    query = @"exec [CMX_AccountList] @v_employeeId=" + request.EmployeeID.ToString() + ", @v_SystemStatus=0, @AccountAge=-1, @MCode=-1, @CCode=-1" + @", @PageSize=" + request.PageSize.ToString() + @", @PageIndex=" + request.PageIndex.ToString();
                }

                listData = await WorksContext.CMX_AccountListView.FromSql(query).ToListAsync();
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
                WriteLog(ex, nameof(HomeController) + "-" + nameof(FilterAccountListByParams), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// FilterWorkplanToDoListByParams
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="500">Have Error</response>
        [HttpPost("workplan-todo-list/filter", Name = nameof(HomeController) + nameof(FilterWorkplanToDoListByParams))]
        public async Task<IActionResult> FilterWorkplanToDoListByParams([FromBody] HomeTodoListFilterByParamsRequest request)
        {
            try
            {
                List<CMX_AccountTodoListView> listData = new List<CMX_AccountTodoListView>();

                string query = "";
                if (request.PageSize <= 0)
                {
                    query = "EXEC [CMX_AccountTodoList]  @TicketDefinitionID=-1, @EmployeeID=" + request.EmployeeId.ToString() + ", @TicketID=0, @SortField='TicketID', @SortDir='DESC', @PageSize=40, @PageIndex=0";
                }
                else
                {
                    query = "EXEC [CMX_AccountTodoList]  @TicketDefinitionID=-1, @EmployeeID=" + request.EmployeeId.ToString() + ", @TicketID=0, @SortField='TicketID', @SortDir='DESC'" + @", @PageSize=" + request.PageSize.ToString() + @", @PageIndex=" + request.PageIndex.ToString();
                }

                listData = await WorksContext.CMX_AccountTodoListView.FromSql(query).ToListAsync();
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
                WriteLog(ex, nameof(HomeController) + "-" + nameof(FilterWorkplanToDoListByParams), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetActionList
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("action-list", Name = nameof(HomeController) + nameof(GetActionList))]
        public async Task<IActionResult> GetActionList()
        {
            try
            {
                var result = await (from a in WorksContext.Account
                                    from d in WorksContext.DebtorInformation.Where(d => d.DebtorID == a.DebtorID)
                                    from pa in WorksContext.PersonAddress.Where(pa => pa.PersonID == d.PersonID && pa.MailingAddress == true)
                                    select new
                                    {
                                        AccountID = a.AccountID,
                                        InvoiceNumber = a.InvoiceNumber,
                                        Address = pa.Address1 + " " + pa.Address2 + " " + pa.Address3,
                                        Zip = pa.Zip,
                                        BillAmount = a.BillAmount,
                                        BillBalance = a.BillBalance,
                                        AccountAge = a.AccountAge,
                                        LastAllocationDate = a.LastAllocationDate,
                                        ActionEmployee = a.ActionEmployee,
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
                WriteLog(ex, nameof(HomeController) + "-" + nameof(GetActionList), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetActionListByEmployee
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("action-list/{employeeId}", Name = nameof(HomeController) + nameof(GetActionListByEmployee))]
        public async Task<IActionResult> GetActionListByEmployee(int employeeId)
        {
            try
            {
                var result = await (from a in WorksContext.Account.Where(a => a.EmployeeID == employeeId)
                                    from d in WorksContext.DebtorInformation.Where(d => d.DebtorID == a.DebtorID)
                                    from p in WorksContext.PersonInformation.Where(p => p.PersonID == d.PersonID)
                                    from pa in WorksContext.PersonAddress.Where(pa => pa.PersonID == d.PersonID && pa.MailingAddress == true)

                                    select new
                                    {
                                        DebtorID = a.DebtorID,
                                        AccountID = a.AccountID,
                                        InvoiceNumber = a.InvoiceNumber,
                                        Address = pa.Address1 + " " + pa.Address2 + " " + pa.Address3,
                                        Zip = pa.Zip,
                                        BillAmount = a.BillAmount,
                                        BillBalance = a.BillBalance,
                                        AccountAge = a.AccountAge,
                                        LastAllocationDate = a.LastAllocationDate,
                                        ActionEmployee = a.ActionEmployee,
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
                WriteLog(ex, nameof(HomeController) + "-" + nameof(GetActionListByEmployee), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetFilterWorkplanToDoList
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("workplan-todo-list/{activityStatus}/{assignTo}", Name = nameof(HomeController) + nameof(GetFilterWorkplanToDoList))]
        public async Task<IActionResult> GetFilterWorkplanToDoList(string activityStatus, int assignTo)
        {
            try
            {
                var result = await (from at in WorksContext.CWX_AccountTicket
                                    from ata in WorksContext.CWX_AccountTicketActivity.Where(ata => ata.AccountTicketID == at.TicketID && ata.ActivityStatus == activityStatus && ata.AssignTo == assignTo)
                                    from a in WorksContext.Account.Where(a => a.AccountID == at.AccountID)
                                    from d in WorksContext.DebtorInformation.Where(d => d.DebtorID == a.DebtorID)
                                    from p in WorksContext.PersonInformation.Where(p => p.PersonID == d.PersonID)
                                    from pa in WorksContext.PersonAddress.Where(pa => pa.PersonID == d.PersonID && pa.MailingAddress == true)
                                    select new
                                    {
                                        BillAmount = a.BillAmount,
                                        TicketID = at.TicketID,
                                        DebtorID = a.DebtorID,
                                        AccountID = a.AccountID,
                                        InvoiceNumber = a.InvoiceNumber,
                                        CustomerName = p.FirstName + " " + p.MiddleName + " " + p.LastName,
                                        Address = pa.Address1 + " " + pa.Address2 + " " + pa.Address3,
                                        Zip = pa.Zip,
                                        Workplan = at.Description,
                                        Activity = ata.Description,
                                        PlanStartDate = ata.PlanStartDate,
                                        PlanDueDate = ata.PlanDueDate
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
                WriteLog(ex, nameof(HomeController) + "-" + nameof(GetFilterWorkplanToDoList), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetrWorkplanToDoList
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("workplan-todo-list", Name = nameof(HomeController) + nameof(GetrWorkplanToDoList))]
        public async Task<IActionResult> GetrWorkplanToDoList()
        {
            try
            {
                var result = await (from at in WorksContext.CWX_AccountTicket
                                    from ata in WorksContext.CWX_AccountTicketActivity.Where(ata => ata.AccountTicketID == at.TicketID)
                                    from a in WorksContext.Account.Where(a => a.AccountID == at.AccountID)
                                    from d in WorksContext.DebtorInformation.Where(d => d.DebtorID == a.DebtorID)
                                    from pa in WorksContext.PersonAddress.Where(pa => pa.PersonID == d.PersonID && pa.MailingAddress == true)
                                    select new
                                    {
                                        AccountID = a.AccountID,
                                        InvoiceNumber = a.InvoiceNumber,
                                        Address = pa.Address1 + " " + pa.Address2 + " " + pa.Address3,
                                        Zip = pa.Zip,
                                        Workplan = at.Description,
                                        Activity = ata.Description,
                                        PlanStartDate = ata.PlanStartDate,
                                        PlanDueDate = ata.PlanDueDate
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
                WriteLog(ex, nameof(HomeController) + "-" + nameof(GetrWorkplanToDoList), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }



        /// <summary>
        /// GetTodayBucketOfAccount
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("today-bucket-account/{arrAccountId}", Name = nameof(HomeController) + nameof(GetTodayBucketOfAccount))]
        public async Task<IActionResult> GetTodayBucketOfAccount(string arrAccountId)
        {
            try
            {
                arrAccountId = arrAccountId.Trim().Replace("{", "").Replace("}", "");

                string[] param = arrAccountId.Split(",");
                int[] iArrAccountId = new int[param.Length];
                for(int i=0; i< param.Length; i++)
                {
                    try
                    {
                        iArrAccountId[i] = Convert.ToInt32(param[i].Trim());
                    }
                    catch
                    {
                    }
                }

                var result = await (from a in WorksContext.Account.Where(a => iArrAccountId.Contains(a.AccountID))
                                    from d in WorksContext.DebtorInformation.Where(d => d.DebtorID == a.DebtorID)
                                    from pa in WorksContext.PersonAddress.Where(pa => pa.PersonID == d.PersonID && pa.MailingAddress == true)

                                    select new
                                    {
                                        DebtorID = a.DebtorID,
                                        AccountID = a.AccountID,
                                        InvoiceNumber = a.InvoiceNumber,
                                        Address = pa.Address1 + " " + pa.Address2 + " " + pa.Address3,
                                        Zip = pa.Zip,
                                        BillAmount = a.BillAmount,
                                        BillBalance = a.BillBalance,
                                        AccountAge = a.AccountAge,
                                        LastAllocationDate = a.LastAllocationDate,
                                        ActionEmployee = a.ActionEmployee,
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
                WriteLog(ex, nameof(HomeController) + "-" + nameof(GetTodayBucketOfAccount), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }
    }
}