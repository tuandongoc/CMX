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
    public class ActivityController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="configuration"></param>
        /// <param name="logger"></param>
        public ActivityController(CWorksContext context, IConfiguration configuration, ILogger<ActivityController> logger) : base(context, configuration, logger)
        {
        }


        /// <summary>
        /// GetActionList
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("action-list/{employeeID}", Name = nameof(ActivityController) + nameof(GetActionList))]
        public async Task<IActionResult> GetActionList(string employeeID)
        {
            try
            {
                List<CMX_ActionListView> listData = new List<CMX_ActionListView>();
                var strSQL = @"EXEC CMX_ActionList @EmployeeID=" + employeeID;
                listData = await WorksContext.CMX_ActionListView.FromSql(strSQL).ToListAsync();
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
                WriteLog(ex, nameof(ActivityController) + "-" + nameof(GetActionList), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetActionOtherByCodeType
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("action-other-list/{codeType}", Name = nameof(ActivityController) + nameof(GetActionOtherByCodeType))]
        public async Task<IActionResult> GetActionOtherByCodeType(int codeType)
        {
            try
            {
                var result = await (from a in WorksContext.AccountCodeMaster.Where(a => a.Status == "A" && a.CodeType == codeType)
                                    select new
                                    {
                                        CodeID = a.CodeID,
                                        CodeDesc = a.CodeDesc
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
                WriteLog(ex, nameof(ActivityController) + "-" + nameof(GetActionOtherByCodeType), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetActionOtherList
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("action-other-list", Name = nameof(ActivityController) + nameof(GetActionOtherList))]
        public async Task<IActionResult> GetActionOtherList()
        {
            try
            {
                var result = await (from a in WorksContext.AccountCodeMaster.Where(a => a.Status == "A")

                                    select new
                                    {
                                        CodeID = a.CodeID,
                                        CodeDesc = a.CodeDesc
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
                WriteLog(ex, nameof(ActivityController) + "-" + nameof(GetActionOtherList), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetDetailComment
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("detail-comment/{accountTicketId}/{accountTicketActivityId}", Name = nameof(ActivityController) + nameof(GetDetailComment))]
        public async Task<IActionResult> GetDetailComment(int accountTicketId, int accountTicketActivityId)
        {
            try
            {
                var result = await (from ataa in WorksContext.CWX_AccountTicketActivityAction
                                    .Where(ataa => ataa.Action == "Noted" 
                                        && ataa.Type == "Note" 
                                        && ataa.AccountTicketID == accountTicketId 
                                        && ataa.AccountTicketActivityID == accountTicketActivityId)
                                    .OrderByDescending(ataa => ataa.ActionDate)
                                    select new
                                    {
                                        TicketActivityActionID = ataa.TicketActivityActionID,
                                        AccountTicketID = ataa.AccountTicketID,
                                        AccountTicketActivityID = ataa.AccountTicketActivityID,
                                        Comment = ataa.Comment,
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
                WriteLog(ex, nameof(ActivityController) + "-" + nameof(GetDetailComment), LogLevel.Error, false);

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
        [HttpGet("detail-comment-list", Name = nameof(ActivityController) + nameof(GetDetailCommentList))]
        public async Task<IActionResult> GetDetailCommentList()
        {
            try
            {
                var result = await (from ataa in WorksContext.CWX_AccountTicketActivityAction.Where(ataa => ataa.Action == "Noted" && ataa.Type == "Note")
                                    .OrderByDescending(ataa => ataa.ActionDate)
                                    select new
                                    {
                                        TicketActivityActionID = ataa.TicketActivityActionID,
                                        AccountTicketID = ataa.AccountTicketID,
                                        AccountTicketActivityID = ataa.AccountTicketActivityID,
                                        Comment = ataa.Comment,
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
                WriteLog(ex, nameof(ActivityController) + "-" + nameof(GetDetailCommentList), LogLevel.Error, false);

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
        [HttpGet("detail-description/{accountTicketActivityId}", Name = nameof(ActivityController) + nameof(GetDetailDescription))]
        public async Task<IActionResult> GetDetailDescription(int accountTicketActivityId)
        {
            try
            {
                var result = await (from ata in WorksContext.CWX_AccountTicketActivity.Where(ata => ata.AccountTicketActivityID == accountTicketActivityId)
                                    from ea in WorksContext.Employee.Where(ea => ea.EmployeeID == ata.AssignTo).DefaultIfEmpty()
                                    from ec in WorksContext.Employee.Where(ec => ec.EmployeeID == ata.CreatedBy).DefaultIfEmpty()
                                    from eu in WorksContext.Employee.Where(eu => eu.EmployeeID == ata.UpdatedBy).DefaultIfEmpty()
                                    select new
                                    {
                                        AccountTicketActivityID = ata.AccountTicketActivityID,
                                        ActivityName = ata.Description,
                                        PlanStartDate = ata.PlanStartDate,
                                        StartDate = ata.StartDate,
                                        PlanDueDate = ata.PlanDueDate,
                                        DueDate = ata.DueDate,
                                        ActivityStatus = ata.ActivityStatus,
                                        Assignee = ea.EmployeeName,
                                        Creator = ea.EmployeeName,
                                        CreatedDate = ata.CreatedDate,
                                        UpdatedBy = eu.EmployeeName,
                                        UpdatedDate = ata.UpdatedDate
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
                WriteLog(ex, nameof(ActivityController) + "-" + nameof(GetDetailDescriptionList), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetDetailDescriptionList
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("detail-description-list", Name = nameof(ActivityController) + nameof(GetDetailDescriptionList))]
        public async Task<IActionResult> GetDetailDescriptionList()
        {
            try
            {
                var result = await (from ata in WorksContext.CWX_AccountTicketActivity
                                    from ea in WorksContext.Employee.Where(ea => ea.EmployeeID == ata.AssignTo).DefaultIfEmpty()
                                    from ec in WorksContext.Employee.Where(ec => ec.EmployeeID == ata.CreatedBy).DefaultIfEmpty()
                                    from eu in WorksContext.Employee.Where(eu => eu.EmployeeID == ata.UpdatedBy).DefaultIfEmpty()
                                    select new
                                    {
                                        AccountTicketActivityID = ata.AccountTicketActivityID,
                                        ActivityName = ata.Description,
                                        PlanStartDate = ata.PlanStartDate,
                                        StartDate = ata.StartDate,
                                        PlanDueDate = ata.PlanDueDate,
                                        DueDate = ata.DueDate,
                                        ActivityStatus = ata.ActivityStatus,
                                        Assignee = ea.EmployeeName,
                                        Creator = ea.EmployeeName,
                                        CreatedDate = ata.CreatedDate,
                                        UpdatedBy = eu.EmployeeName,
                                        UpdatedDate = ata.UpdatedDate
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
                WriteLog(ex, nameof(ActivityController) + "-" + nameof(GetDetailDescriptionList), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetResultProcessingRuleAction
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("result-processing-rule-action", Name = nameof(ActivityController) + nameof(GetResultProcessingRuleAction))]
        public async Task<IActionResult> GetResultProcessingRuleAction()
        {
            try
            {
                var result = await (from rt in WorksContext.RuleTable.Where(rt => rt.Status == "A" && rt.RuleType == 3)
                                    from ro in WorksContext.RuleOthers.Where(ro => ro.RuleId == rt.ID)
                                    select new
                                    {
                                        RuleID = rt.ID,
                                        RuleName = rt.Description,
                                        Category = rt.Category,
                                        OptionType = ro.OptionType,
                                        Value = ro.Value,
                                        Value2 = ro.Value2,
                                        Value3 = ro.Value3,
                                        Value4 = ro.Value4,
                                        Value5 = ro.Value5
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
                WriteLog(ex, nameof(ActivityController) + "-" + nameof(GetResultProcessingRuleAction), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetResultProcessingRuleCriteria
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("result-processing-rule-criteria", Name = nameof(ActivityController) + nameof(GetResultProcessingRuleCriteria))]
        public async Task<IActionResult> GetResultProcessingRuleCriteria()
        {
            try
            {
                var result = await (from rt in WorksContext.RuleTable.Where(rt => rt.Status == "A" && rt.RuleType == 3)
                                    from rc in WorksContext.RuleCriteria.Where(rc => rc.RuleID == rt.ID).DefaultIfEmpty()

                                    select new
                                    {
                                        RuleID = rt.ID,
                                        RuleName = rt.Description,
                                        Category = rt.Category,
                                        Criteria = rc.Criteria,
                                        Operator = rc.Operator,
                                        Combining = rc.Combining,
                                        MatchingCriteria = rc.MatchingCriteria,
                                        MatchingCriteria2 = rc.MatchingCriteria2,
                                        SQLFormat = rc.SQLFormat,
                                        OrderNumber = rc.OrderNumber
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
                WriteLog(ex, nameof(ActivityController) + "-" + nameof(GetResultProcessingRuleCriteria), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// InsertAction
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="201">Created</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="500">Have Error</response>
        [HttpPost("insert-action", Name = nameof(ActivityController) + nameof(InsertAction))]
        public async Task<IActionResult> InsertAction([FromBody] AccountActionsInsertRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                AccountActions accountActions = new AccountActions();
                accountActions.Status = 1;
                accountActions.ResponsibleParty = request.EmployeeID;
                accountActions.Deadline = DateTime.Now;
                accountActions.ActionID = request.ActionID;
                accountActions.DateCompleted = DateTime.Now;
                accountActions.CompletedBy = request.EmployeeID;
                accountActions.AccountID = request.AccountID;
                accountActions.AdditionalData = request.AdditionalData;
                accountActions.UnitCost = 0;

                WorksContext.AccountActions.Add(accountActions);
                await WorksContext.SaveChangesAsync();

                return new ObjectResult(accountActions);
            }
            catch (Exception ex)
            {
                WriteLog(ex, nameof(ActivityController) + "-" + nameof(InsertAction), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// InsertActionOther
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="201">Created</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="500">Have Error</response>
        [HttpPost("insert-action-other", Name = nameof(ActivityController) + nameof(InsertActionOther))]
        public async Task<IActionResult> InsertActionOther([FromBody] AccountActionsOtherInsertRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                AccountActionsOther accountActionsOther = new AccountActionsOther();
                accountActionsOther.AccountID = request.AccountID;
                accountActionsOther.ActionDate = DateTime.Now;
                accountActionsOther.ActionID = request.ActionID;
                accountActionsOther.ActionType = request.ActionType;
                accountActionsOther.CompletedBy = request.CompletedBy;

                WorksContext.AccountActionsOther.Add(accountActionsOther);
                await WorksContext.SaveChangesAsync();

                return new ObjectResult(accountActionsOther);
            }
            catch (Exception ex)
            {
                WriteLog(ex, nameof(ActivityController) + "-" + nameof(InsertActionOther), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// InsertNotes
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="500">Have Error</response>
        [HttpPost("insert-note", Name = nameof(ActivityController) + nameof(InsertNotes))]
        public async Task<IActionResult> InsertNotes([FromBody]NotesCurrentInsertRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                NotesCurrent notesCurrent = new NotesCurrent();
                notesCurrent.EmployeeID = request.EmployeeID;
                notesCurrent.DebtorID = request.DebtorID;
                notesCurrent.BillID = request.AccountID;
                notesCurrent.NoteDateTime = DateTime.Now;
                notesCurrent.NoteType = request.NoteType;
                notesCurrent.NoteText = request.NoteText;
                notesCurrent.NotePriority = request.NotePriority;

                WorksContext.NotesCurrent.Add(notesCurrent);
                await WorksContext.SaveChangesAsync();

                return new ObjectResult(notesCurrent);
            }
            catch (Exception ex)
            {
                WriteLog(ex, nameof(ActivityController) + "-" + nameof(InsertNotes), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }



        /// <summary>
        /// UpdateAccount
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="500">Have Error</response>
        [HttpPost("update-account", Name = nameof(ActivityController) + nameof(UpdateAccount))]
        public async Task<IActionResult> UpdateAccount([FromBody]AccountUpdateRequest request)
        {
            // Validate inputs
            string modelError = string.Empty;
            if (!ModelState.IsValid)
            {
                //status code 400
                return BadRequest();
            }

            if (request == null)
            {
                request = new AccountUpdateRequest();
            }
            else if(request.AccountID < 1)
            {
                return BadRequest("AccountID is invalid!");
            }
            else
            {
                int? actionEmployee = request.ActionEmployee;
                if ((actionEmployee.GetValueOrDefault() < 1) & actionEmployee.HasValue)
                {
                    return BadRequest("ActionEmployee is invalid!");
                }
            }

            try
            {
                string strSQL = @"exec [CMX_Update_Account] @AccountID=";
                strSQL = strSQL + request.AccountID.ToString();
                strSQL = strSQL + @", @QueueDate='";
                strSQL = strSQL + request.QueueDate.ToString();
                strSQL = strSQL + @"', @CurrentAction=";
                strSQL = strSQL + request.CurrentAction.ToString();
                strSQL = strSQL + @", @CurrentNextAction=";
                strSQL = strSQL + request.CurrentNextAction.ToString();
                strSQL = strSQL + @", @AgencyStatusID=";
                strSQL = strSQL + request.AgencyStatusID.ToString();
                strSQL = strSQL + @", @SystemStatusID=";
                strSQL = strSQL + request.SystemStatusID.ToString();
                strSQL = strSQL + @", @ActionEmployee=";
                strSQL = strSQL + request.ActionEmployee.ToString();
                await WorksContext.Database.ExecuteSqlCommandAsync(strSQL);

                return Ok("Update Account successfully!");
            }
            catch (Exception ex)
            {
                WriteLog(ex, nameof(ActivityController) + "-" + nameof(UpdateAccount), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// UpdateStatus
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="500">Have Error</response>
        [HttpPut("update-status/{accountTicketId}", Name = nameof(ActivityController) + nameof(UpdateStatus))]
        public async Task<IActionResult> UpdateStatus(int accountTicketId, [FromBody]StatusUpdateRequest request)
        {
            // Validate inputs
            string modelError = string.Empty;
            if (!ModelState.IsValid)
            {
                //status code 400
                return BadRequest();
            }

            if (request == null)
            {
                request = new StatusUpdateRequest();
            }

            request.AccountTicketID = accountTicketId;
            try
            {
                // Check exist data
                var accountTA = await WorksContext.CWX_AccountTicketActivity.Where(c => c.AccountTicketID == accountTicketId).FirstOrDefaultAsync();
                if (accountTA == null)
                {
                    //status code 404
                    return NotFound();
                }

                accountTA.ActivityStatus = request.ActivityStatus;
                accountTA.StartDate = request.StartDate;
                accountTA.DueDate = request.DueDate;
                accountTA.UpdatedBy = request.UpdatedBy;
                accountTA.UpdatedDate = request.UpdatedDate;
                accountTA.CompletedBy = request.CompletedBy;
                accountTA.CompletedDate = request.CompletedDate;

                WorksContext.SaveChanges();
                return new ObjectResult(accountTA);
            }
            catch (Exception ex)
            {
                WriteLog(ex, nameof(ActivityController) + "-" + nameof(UpdateStatus), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }
    }
}