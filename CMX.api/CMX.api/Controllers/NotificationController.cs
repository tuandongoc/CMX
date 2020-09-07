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
using Microsoft.EntityFrameworkCore.Migrations;
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
    public class NotificationController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        public NotificationController(CWorksContext context, IConfiguration configuration, ILogger<NotificationController> logger) : base(context, configuration, logger)
        {
        }

        /// <summary>
        /// FilterNotificationByEmployee
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Have Error</response>
        [HttpPost("filter", Name = nameof(NotificationController) + nameof(FilterNotificationByEmployee))]
        public async Task<IActionResult> FilterNotificationByEmployee([FromBody] NotificationsFilterByEmployeeRequest request)
        {
            try
            {
                List<CMX_GetMessagingView> listData = new List<CMX_GetMessagingView>();
                string strSQL = @"EXEC [CMX_GetMessaging] @EmployeeID=";
                strSQL = strSQL + request.EmployeeId.ToString();
                
                if(request.PageSize <= 0)
                {
                    strSQL = strSQL + ", @PageSize=40, @PageIndex=0";

                }
                else
                {
                    strSQL = strSQL + ", @PageSize=";
                    strSQL = strSQL + request.PageSize.ToString();
                    strSQL = strSQL + @", @PageIndex = ";
                    strSQL = strSQL + request.PageIndex.ToString();
                }
                listData = await WorksContext.CMX_GetMessagingView.FromSql(strSQL).ToListAsync();

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
                WriteLog(ex, nameof(NotificationController) + "-" + nameof(FilterNotificationByEmployee), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetNotificationByEmployee
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("{employeeId}", Name = nameof(NotificationController) + nameof(GetNotificationByEmployee))]
        public async Task<IActionResult> GetNotificationByEmployee(int employeeId)
        {
            try
            {
                var result = await (from msg in WorksContext.Messages.
                                    Where(  msg => msg.Status == "A" 
                                        && msg.ToEmployee == employeeId
                                        && msg.DisplayOn <= DateTime.Now)
                              select new
                              {
                                  FromName = msg.FromName,
                                  DebtorID = msg.DebtorID,
                                  AccountID = msg.AccountID,
                                  DisplayOn = msg.DisplayOn,
                                  Message = msg.Message,
                                  Active = msg.Active,
                                  EmployeeRead = msg.EmployeeRead
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
            catch (Exception ex)
            {
                WriteLog(ex, nameof(NotificationController) + "-" + nameof(FilterNotificationByEmployee), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }
    }
}