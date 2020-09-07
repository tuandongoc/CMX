using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMX.api.Repositories;
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
    public class RealtimeController : BaseController
    {
        private IOutstandingBalanceRepository outstandingBalanceRepository;

        /// <summary>
        /// 
        /// </summary>
        public RealtimeController(CWorksContext context, IConfiguration configuration, ILogger<RealtimeController> logger, IOutstandingBalanceRepository _outstandingBalanceRepository) : base(context, configuration, logger)
        {
            this.outstandingBalanceRepository = _outstandingBalanceRepository;
        }



        /// <summary>
        /// GetOutstandingBalance
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("outstanding-balance/{invoiceNumber}", Name = nameof(PromiseController) + nameof(GetOutstandingBalance))]
        public async Task<IActionResult> GetOutstandingBalance(string invoiceNumber)
        {
            try
            {
                var outstandingBalance = outstandingBalanceRepository.GetOutstandingBalance(invoiceNumber);
                if(outstandingBalance != null)
                {
                    return new ObjectResult(outstandingBalance);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex, nameof(RealtimeController) + "-" + nameof(GetOutstandingBalance), LogLevel.Error, false);
                // status code = 400
                return BadRequest();
                throw;
            }
        }
    }
}