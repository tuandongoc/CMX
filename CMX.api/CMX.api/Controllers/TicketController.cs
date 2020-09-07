using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class TicketController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        public TicketController(CWorksContext context, IConfiguration configuration, ILogger<TicketController> logger) : base(context, configuration, logger)
        {
        }

        /// <summary>
        /// GetActivityList
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("activity-all", Name = nameof(TicketController) + nameof(GetActivityList))]
        public async Task<IActionResult> GetActivityList()
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
                                        AccountTicketActivityID = ata.AccountTicketActivityID,
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
                WriteLog(ex, nameof(TicketController) + "-" + nameof(GetActivityList), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetActivityListById
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("activity/{id}", Name = nameof(TicketController) + nameof(GetActivityListById))]
        public async Task<IActionResult> GetActivityListById(int id)
        {
            try
            {
                var result = await (from at in WorksContext.CWX_AccountTicket
                                    from ata in WorksContext.CWX_AccountTicketActivity.Where(ata => ata.AccountTicketID == at.TicketID && ata.AccountTicketActivityID == id)
                                    from a in WorksContext.Account.Where(a => a.AccountID == at.AccountID)
                                    from d in WorksContext.DebtorInformation.Where(d => d.DebtorID == a.DebtorID)
                                    from pa in WorksContext.PersonAddress.Where(pa => pa.PersonID == d.PersonID && pa.MailingAddress == true)
                                    select new
                                    {
                                        AccountTicketActivityID = ata.AccountTicketActivityID,
                                        InvoiceNumber = a.InvoiceNumber,
                                        Address = pa.Address1 + " " + pa.Address2 + " " + pa.Address3,
                                        Zip = pa.Zip,
                                        Workplan = at.Description,
                                        Activity = ata.Description,
                                        PlanStartDate = ata.PlanStartDate,
                                        PlanDueDate = ata.PlanDueDate
                                    }
                                ).AsNoTracking().ToListAsync();

                if (result != null && result.Count > 0)
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
                WriteLog(ex, nameof(TicketController) + "-" + nameof(GetActivityListById), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }
    }
}