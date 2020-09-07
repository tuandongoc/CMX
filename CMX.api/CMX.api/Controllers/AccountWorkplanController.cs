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
    public class AccountWorkplanController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        public AccountWorkplanController(CWorksContext context, IConfiguration configuration, ILogger<AccountWorkplanController> logger) : base(context, configuration, logger)
        {
        }

        /// <summary>
        /// FilterAccountWorkplanByParams
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Have Error</response>
        [HttpPost("filter", Name = nameof(AccountWorkplanController) + nameof(FilterAccountWorkplanByParams))]
        public async Task<IActionResult> FilterAccountWorkplanByParams([FromBody] AccountWorkplanListFilterByParamsRequest request)
        {
            try
            {
                List<CMX_AccountWorkplanView> listData = new List<CMX_AccountWorkplanView>();
                string strSQL = "";
                strSQL = @"exec CMX_AccountWorkplan @TicketDefinitionID=-1, @AccountID=";
                strSQL = strSQL + request.AccountID.ToString();
                strSQL = strSQL + @", @EmployeeID=";
                strSQL = strSQL + request.EmployeeID.ToString();

                if(request.PageSize <= 0)
                {
                    strSQL = strSQL + @", @PageSize=40, @PageIndex=0";
                }
                else
                {
                    strSQL = strSQL + @", @PageSize=";
                    strSQL = strSQL + request.PageSize.ToString();
                    strSQL = strSQL + @", @PageIndex=";
                    strSQL = strSQL + request.PageIndex.ToString();
                }

                listData = await WorksContext.CMX_AccountWorkplanView.FromSql(strSQL).ToListAsync();
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
                WriteLog(ex, nameof(AccountWorkplanController) + "-" + nameof(FilterAccountWorkplanByParams), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetAccountWorkplanById
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("{accountId}", Name = nameof(AccountWorkplanController) + nameof(GetAccountWorkplanById))]
        public async Task<IActionResult> GetAccountWorkplanById(int accountId)
        {
            try
            {
                var result = await (from at in WorksContext.CWX_AccountTicket.Where(at => at.AccountID == accountId)
                                    from a in WorksContext.Account.Where(a => a.AccountID == at.AccountID)
                                    from tc in WorksContext.Employee.Where(tc => tc.EmployeeID == at.CreatedBy).DefaultIfEmpty()
                                    from tu in WorksContext.Employee.Where(tu => tu.EmployeeID == at.UpdatedBy).DefaultIfEmpty()
                                    select new
                                    {
                                        TicketID = at.TicketID,
                                        Workplan = at.Description,
                                        TC_EmployeeName = tc.EmployeeName,
                                        CreatedDate = at.CreatedDate,
                                        DueDate = at.DueDate,
                                        TicketStatus = at.TicketStatus,
                                        TU_EmployeeName = tu.EmployeeName,
                                        UpdatedDate = at.UpdatedDate
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
                WriteLog(ex, nameof(AccountWorkplanController) + "-" + nameof(GetAccountWorkplanById), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetAccountWorkplanList
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("all", Name = nameof(AccountWorkplanController) + nameof(GetAccountWorkplanList))]
        public async Task<IActionResult> GetAccountWorkplanList()
        {
            try
            {
                var result = await (from at in WorksContext.CWX_AccountTicket
                                    from a in WorksContext.Account.Where(a => a.AccountID == at.AccountID)
                                    from tc in WorksContext.Employee.Where(tc => tc.EmployeeID == at.CreatedBy).DefaultIfEmpty()
                                    from tu in WorksContext.Employee.Where(tu => tu.EmployeeID == at.UpdatedBy).DefaultIfEmpty()
                                    select new
                                    {
                                        TicketID = at.TicketID,
                                        Workplan = at.Description,
                                        TC_EmployeeName = tc.EmployeeName,
                                        CreatedDate = at.CreatedDate,
                                        DueDate = at.DueDate,
                                        TicketStatus = at.TicketStatus,
                                        TU_EmployeeName = tu.EmployeeName,
                                        UpdatedDate = at.UpdatedDate
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
                WriteLog(ex, nameof(AccountWorkplanController) + "-" + nameof(GetAccountWorkplanList), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }
    }
}