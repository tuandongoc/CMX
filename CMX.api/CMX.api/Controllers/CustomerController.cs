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
    public class CustomerController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        public CustomerController(CWorksContext context, IConfiguration configuration, ILogger<ActivityController> logger) : base(context, configuration, logger)
        {
        }


        /// <summary>
        /// UpdateAddress
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="500">Have Error</response>
        [HttpPut("update-address/{employeeId}", Name = nameof(CustomerController) + nameof(UpdateAddress))]
        public async Task<IActionResult> UpdateAddress(int employeeId, [FromBody]CustomerAddressUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (request == null)
            {
                request = new CustomerAddressUpdateRequest();
            }
            request.EmployeeID = employeeId;

            try
            {
                string strSQL = @"exec [CMX_CustomerAddress_Update] @EmployeeID=";
                strSQL = strSQL + request.EmployeeID.ToString();
                strSQL = strSQL + @", @AccountID=";
                strSQL = strSQL + request.AccountID.ToString();
                strSQL = strSQL + @", @Address=N'";
                strSQL = strSQL + request.Address.Trim() + "' ";
                await WorksContext.Database.ExecuteSqlCommandAsync(strSQL);

                return Ok("Update customer address successfully!");
            }
            catch (Exception ex)
            {
                WriteLog(ex, nameof(CustomerController) + "-" + nameof(UpdateAddress), LogLevel.Error, false);

                // status code = 400
                return BadRequest();
                throw;
            }
        }
    }
}