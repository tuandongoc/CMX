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
    public class AccountCollateralController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        public AccountCollateralController(CWorksContext context, IConfiguration configuration, ILogger<AccountCollateralController> logger) : base(context, configuration, logger)
        {
        }


        /// <summary>
        /// Get
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("get/{accountID}/{collateralID}", Name = nameof(AccountCollateralController) + nameof(Get))]
        public async Task<IActionResult> Get(int accountID, int collateralID)
        {
            try
            {
                List<CMX_AccountCollateral_GetView> listData = new List<CMX_AccountCollateral_GetView>();
                string strSQL = "EXEC CMX_AccountCollateral_Get @CollateralID=" + collateralID.ToString() + ", @AccountID=" + accountID.ToString();
                var result = await WorksContext.CMX_AccountCollateral_GetView.FromSql(strSQL).ToListAsync();

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
                WriteLog(ex, nameof(AccountCollateralController) + "-" + nameof(Get), LogLevel.Error, false);
                // status code = 400
                return BadRequest();
                throw;
            }
        }

        /// <summary>
        /// GetList
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="404">Not Found</response>
        /// <response code="500">Have Error</response>
        [HttpGet("getlist/{accountID}", Name = nameof(AccountCollateralController) + nameof(GetList))]
        public async Task<IActionResult> GetList(int accountID)
        {
            try
            {
                List<CMX_AccountCollateral_GetListView> listData = new List<CMX_AccountCollateral_GetListView>();
                string strSQL = "EXEC CMX_AccountCollateral_GetList @AccountID=" + accountID.ToString();
                var result = await WorksContext.CMX_AccountCollateral_GetListView.FromSql(strSQL).ToListAsync();

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
                WriteLog(ex, nameof(AccountCollateralController) + "-" + nameof(GetList), LogLevel.Error, false);
                // status code = 400
                return BadRequest();
                throw;
            }
        }
    }
}