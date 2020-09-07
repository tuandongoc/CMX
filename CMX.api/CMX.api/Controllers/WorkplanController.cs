using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMX.Entities.Models.POST;
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
    public class WorkplanController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        public WorkplanController(CWorksContext context, IConfiguration configuration, ILogger<WorkplanController> logger) : base(context, configuration, logger)
        {
        }

        /// <summary>
        /// DeleteComment
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="204">No content</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Have Error</response>
        [HttpDelete("delete-comment/{ticketActivityActionId}", Name = nameof(WorkplanController) + nameof(DeleteComment))]
        public async Task<IActionResult> DeleteComment(int ticketActivityActionId)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                // Check exist data
                var account = await WorksContext.CWX_AccountTicketActivityAction.Where(c => c.TicketActivityActionID == ticketActivityActionId).FirstOrDefaultAsync();
                if (account == null)
                {
                    //status code 404
                    return NotFound();
                }

                WorksContext.CWX_AccountTicketActivityAction.Remove(account);
                await WorksContext.SaveChangesAsync();

                //status code 204
                return NoContent();
            }
            catch (Exception ex)
            {
                WriteLog(ex, nameof(WorkplanController) + "-" + nameof(DeleteComment), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetDetailActivityList
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("activity-list/{ticketId}", Name = nameof(WorkplanController) + nameof(GetDetailActivityList))]
        public async Task<IActionResult> GetDetailActivityList(int ticketId)
        {
            try
            {
                var result = await (from at in WorksContext.CWX_AccountTicket.Where(at => at.TicketID == ticketId)
                                    from ata in WorksContext.CWX_AccountTicketActivity.Where(ata => ata.AccountTicketID == at.TicketID)
                                    from ta in WorksContext.Employee.Where(ta => ta.EmployeeID == ata.AssignTo).DefaultIfEmpty()
                                    select new
                                    {
                                        TicketActivityID = ata.TicketActivityID,
                                        Description = ata.Description,
                                        ActivityStatus = ata.ActivityStatus,
                                        Assignee = ta.EmployeeName,
                                        PlanStartDate = ata.PlanStartDate,
                                        PlanDueDate = ata.PlanDueDate,
                                        StartDate = ata.StartDate,
                                        DueDate = ata.DueDate
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
                WriteLog(ex, nameof(WorkplanController) + "-" + nameof(GetDetailActivityList), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetDetailApproverList
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("approver-list/{ticketId}", Name = nameof(WorkplanController) + nameof(GetDetailApproverList))]
        public async Task<IActionResult> GetDetailApproverList(int ticketId)
        {
            try
            {
                var result = await (from at in WorksContext.CWX_AccountTicket.Where(at => at.TicketID == ticketId)
                                    from tap in WorksContext.CWX_TicketApproval.Where(tap => tap.TicketApprovalRefID == at.TicketID && tap.Location == "TICKET")
                                    from app in WorksContext.Employee.Where(app => app.EmployeeID == tap.ApproverID).DefaultIfEmpty()
                                    from act in WorksContext.Employee.Where(act => act.EmployeeID == tap.ActionedBy).DefaultIfEmpty()
                                    select new
                                    {
                                        TicketApprovalID = tap.TicketApprovalID,
                                        Approver = app.EmployeeName,
                                        ApproverLevel = tap.ApproverLevel,
                                        ApprovalStatus = tap.ApprovalStatus,
                                        ActionedDate = tap.ActionedDate,
                                        ActionedBy = tap.ActionedBy
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
                WriteLog(ex, nameof(WorkplanController) + "-" + nameof(GetDetailApproverList), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetDetailCommentList
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("comment-list/{accountTicketId}", Name = nameof(WorkplanController) + nameof(GetDetailCommentList))]
        public async Task<IActionResult> GetDetailCommentList(int accountTicketId)
        {
            try
            {
                var result = await (from ataa in WorksContext.CWX_AccountTicketActivityAction.Where(ataa => ataa.AccountTicketID == accountTicketId && ataa.Action == "Noted" && ataa.Type == "Note")
                                    from act in WorksContext.Employee.Where(act => act.EmployeeID == ataa.ActionBy)
                                    select new
                                    {
                                        TicketActivityActionID = ataa.TicketActivityActionID,
                                        AccountTicketID = ataa.AccountTicketID,
                                        ActionDate = ataa.ActionDate,
                                        EmployeeName = act.EmployeeName,
                                        Comment = ataa.Comment
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
                WriteLog(ex, nameof(WorkplanController) + "-" + nameof(GetDetailCommentList), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetDetailDescription
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("description/{ticketId}", Name = nameof(WorkplanController) + nameof(GetDetailDescription))]
        public async Task<IActionResult> GetDetailDescription(int ticketId)
        {
            try
            {
                var result = await (from at in WorksContext.CWX_AccountTicket.Where(at => at.TicketID == ticketId)
                                    from a in WorksContext.Account.Where(a => a.AccountID == at.AccountID)
                                    from ta in WorksContext.Employee.Where(ta => ta.EmployeeID == at.AssignTo)
                                    from tc in WorksContext.Employee.Where(tc => tc.EmployeeID == at.CreatedBy)
                                    from tu in WorksContext.Employee.Where(tu => tu.EmployeeID == at.UpdatedBy)
                                    select new
                                    {
                                        TicketID = at.TicketID,
                                        Workplan = at.Description,
                                        Assignee = ta.EmployeeName,
                                        Creator = tc.EmployeeName,
                                        CreatedDate = at.CreatedDate,
                                        DueDate = at.DueDate,
                                        TicketStatus = at.TicketStatus,
                                        UpdatedBy = tu.EmployeeName,
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
                WriteLog(ex, nameof(WorkplanController) + "-" + nameof(GetDetailDescription), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// InsertComment
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="201">Created</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="500">Have Error</response>
        [HttpPost("insert-comment", Name = nameof(WorkplanController) + nameof(InsertComment))]
        public async Task<IActionResult> InsertComment([FromBody]CWXAccountTicketActivityActionInsertRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                CWX_AccountTicketActivityAction CWXaccount = new CWX_AccountTicketActivityAction();
                CWXaccount.AccountTicketID = request.AccountTicketID;
                CWXaccount.TicketActivityID = -1;
                CWXaccount.AccountTicketActivityID = request.AccountTicketActivityID;
                CWXaccount.Level = -1;
                CWXaccount.PermissionType = -1;
                CWXaccount.Action = "Noted";
                CWXaccount.ActionBy = request.EmployeeID;
                CWXaccount.ActionDate = DateTime.Now;
                CWXaccount.ApproverID = 0;
                CWXaccount.Type = "Note";
                CWXaccount.Status = "A";
                CWXaccount.Comment = request.Comment;

                WorksContext.CWX_AccountTicketActivityAction.Add(CWXaccount);
                await WorksContext.SaveChangesAsync();

                return new ObjectResult(CWXaccount);
            }
            catch (Exception ex)
            {
                WriteLog(ex, nameof(WorkplanController) + "-" + nameof(InsertComment), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }
    }
}