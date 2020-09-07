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
    public class NotesController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        public NotesController(CWorksContext context, IConfiguration configuration, ILogger<NotesController> logger) : base(context, configuration, logger)
        {
        }

        /// <summary>
        /// FilterByParams
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("{billId}/{debtorId}/{noteType}", Name = nameof(NotesController) + nameof(FilterByParams))]
        public async Task<IActionResult> FilterByParams(int billId, int debtorId, string noteType)
        {
            try
            {
                var result = await (from nc in WorksContext.NotesCurrent.Where(nc => (nc.BillID == billId || nc.DebtorID == debtorId) && nc.NoteType == noteType).OrderBy(nc => nc.NoteDateTime)
                                    from e in WorksContext.Employee.Where(e => e.EmployeeID == nc.EmployeeID).DefaultIfEmpty()

                                    select new
                                    {
                                        NoteID = nc.NoteID,
                                        EmployeeName = e.EmployeeName,
                                        DebtorID = nc.DebtorID,
                                        BillID = nc.BillID,
                                        NoteDateTime = nc.NoteDateTime,
                                        NoteType = nc.NoteType,
                                        NoteText = nc.NoteText,
                                        NotePriority = nc.NotePriority
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
                WriteLog(ex, nameof(NotesController) + "-" + nameof(FilterByParams), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// FilterByParams2
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Have Error</response>
        [HttpPost("filter", Name = nameof(NotesController) + nameof(FilterByParams2))]
        public async Task<IActionResult> FilterByParams2([FromBody] NotesFilterByParamsRequest request)
        {
            try
            {
                List<CMX_NotesSearchView> listData = new List<CMX_NotesSearchView>();
                string query = "";
                if (request.PageSize <= 0)
                {
                    query = "exec [CMX_NotesSearch] @DebtorID=" + request.DebtorID.ToString() + @", @AccountID=" + request.AccountID.ToString() + @", @NoteText = N'" + request.NoteText + @"', @NoteType = N'" + request.NoteType + "', @Month=-1, @Day=-1, @SearchHistory=0, @SearchByAccount=1, @NotePriority=-1, @PageSize=40, @PageIndex=0";
                }
                else
                {
                    query = "exec [CMX_NotesSearch] @DebtorID=" + request.DebtorID.ToString() + @", @AccountID=" + request.AccountID.ToString() + @", @NoteText = N'" + request.NoteText + @"', @NoteType = N'" + request.NoteType + "', @Month=-1, @Day=-1, @SearchHistory=0, @SearchByAccount=1, @NotePriority=-1" + @", @PageSize =" + request.PageSize.ToString() + @", @PageIndex=" + request.PageIndex.ToString();
                }

                listData = await WorksContext.CMX_NotesSearchView.FromSql(query).ToListAsync();
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
                WriteLog(ex, nameof(NotesController) + "-" + nameof(FilterByParams2), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("all", Name = nameof(NotesController) + nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await (from nc in WorksContext.NotesCurrent.OrderBy(nc => nc.NoteDateTime)
                                    from e in WorksContext.Employee.Where(e => e.EmployeeID == nc.EmployeeID).DefaultIfEmpty()

                                    select new
                                    {
                                        NoteID = nc.NoteID,
                                        EmployeeName = e.EmployeeName,
                                        DebtorID = nc.DebtorID,
                                        BillID = nc.BillID,
                                        NoteDateTime = nc.NoteDateTime,
                                        NoteType = nc.NoteType,
                                        NoteText = nc.NoteText,
                                        NotePriority = nc.NotePriority
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
                WriteLog(ex, nameof(NotesController) + "-" + nameof(GetAll), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }
    }
}