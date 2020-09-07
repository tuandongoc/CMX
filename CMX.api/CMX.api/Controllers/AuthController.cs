using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using CMX.Entities.Models.Core;
using CMX.Entities.Models.POST;
using CMX.Entities.Models.UIModels;
using CMX.Entities.Models.Works;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace CMX.api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        /// <summary>
        /// 
        /// </summary>
        public AuthController(CWorksContext context, CoreContext coreContext, IConfiguration configuration, ILogger<AuthController> logger) : base(context, coreContext, configuration, logger)
        {
        }

        /// <summary>
        /// Login
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="500">Have Error</response>
        [HttpPost("login", Name = nameof(AuthController) + nameof(Login))]
        public ActionResult Login([FromBody]LoginRequest request)
        {
            ActionResult result;
            if ((request.Username == null) || string.IsNullOrEmpty(request.Username))
            {
                return this.BadRequest("Username is invalid");
            }
            if ((request.Password == null) || string.IsNullOrEmpty(request.Password))
            {
                return this.BadRequest("Password is invalid");
            }

            bool flag = false;
            try
            {
                //DirectorySearcher searcher = new DirectorySearcher(new DirectoryEntry("LDAP://shbho.shb.vn", request.Username, request.Password))
                //{
                //    Filter = "sAMAccountName=" + request.Username
                //};
                //if (searcher.FindOne() != null)
                //{
                //    flag = true;
                //}

                flag = true;
                if (flag)
                {
                    if (flag)
                    {
                        List<CMX_LoginView> lstUser = new List<CMX_LoginView>();
                        string strQuery = "exec [CMX_Login] @UserName=" + request.Username;
                        lstUser = WorksContext.CMX_LoginView.FromSql(strQuery).ToList();
                        if (!lstUser.Any())
                        {
                            return this.BadRequest("Username or password invalid");
                        }

                        return new ObjectResult(lstUser[0]);
                    }

                    string secKey = "dfe08d867458c032a10c22aff0714bbf";
                    string usrData = request.Username + secKey + request.Password;
                    SigningCredentials signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secKey)), "http://www.w3.org/2001/04/xmldsig-more#hmac-sha256");
                    List<Claim> listClaim = new List<Claim> 
                    {
                        new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/userdata", usrData),
                        new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Administrator"),
                        new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Reader")
                    };
                    DateTime? dtExpires = new DateTime?(DateTime.Now.AddHours(1));
                    DateTime? notBefore = null;
                    JwtSecurityToken token = new JwtSecurityToken("CMX.app", "readers", (IEnumerable<Claim>)listClaim, notBefore, dtExpires, signingCredentials);
                    return this.Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }

                result = this.BadRequest("Username or password invalid");

            }
            catch (DirectoryServicesCOMException ex)
            {
                WriteLog((Exception)ex, "AuthController-Login", LogLevel.Error, false);
                throw new Exception(ex.ToString());
            }
            return result;
        }

        /// <summary>
        /// InsertLogAttempt
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="201">Created</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="500">Have Error</response>
        [HttpPost("insertlogattempt", Name = nameof(AuthController) + nameof(InsertLogAttempt))]
        public ActionResult InsertLogAttempt([FromBody] InsertLogAttemptRequest request)
        {
            ActionResult result;
            try
            {
                if ((request.LoginUser == null) || string.IsNullOrEmpty(request.LoginUser))
                {
                    result = this.BadRequest("LoginUser is invalid");
                }
                else if ((request.IPAddress == null) || string.IsNullOrEmpty(request.IPAddress))
                {
                    result = this.BadRequest("IPAddress is invalid");
                }
                else if ((request.LoginStatus == null) || string.IsNullOrEmpty(request.LoginStatus))
                {
                    result = this.BadRequest("LoginStatus is invalid");
                }
                else
                {
                    if ((request.Reason == null) || string.IsNullOrEmpty(request.Reason))
                    {
                        request.Reason = "";
                    }

                    string strQuery = @"exec [CMX_LoginAttemptsLog_Insert] @LoginUser=";
                    strQuery = strQuery + request.LoginUser;
                    strQuery = strQuery + @", @LoginDateTime='";
                    strQuery = strQuery + DateTime.Now.ToString();
                    strQuery = strQuery + @"', @IPAddress=";
                    strQuery = strQuery + request.IPAddress;
                    strQuery = strQuery + @", @LoginStatus=";
                    strQuery = strQuery + request.LoginStatus;
                    strQuery = strQuery + @", @Reason=";
                    strQuery = strQuery + request.Reason;
                    CoreContext.Database.ExecuteSqlCommand(strQuery);
                    result = this.Ok("Insert AttemptLog successfully!");
                }
            }
            catch (Exception ex)
            {
                WriteLog(ex, "AuthController-InsertLogAttempt", LogLevel.Error, false);
                result = this.BadRequest("nsert AttemptLog failure!");
            }
            return result;
        }

        /// <summary>
        /// InsertLoginLog
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="201">Created</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="500">Have Error</response>
        [HttpPost("insertloginlog", Name = nameof(AuthController) + nameof(InsertLoginLog))]
        public ActionResult InsertLoginLog([FromBody] InsertLoginLogRequest request)
        {
            ActionResult result;
            try
            {
                int userID = request.UserID;
                if (request.UserID <= 0)
                {
                    result = this.BadRequest("UserID is invalid");
                }
                else
                {
                    DateTime loginTime = request.LoginTime;
                    if (request.LoginTime.Year == 1)
                    {
                        result = this.BadRequest("LoginTime is invalid");
                    }
                    else
                    {
                        DateTime minValue = DateTime.MinValue;
                        string sqlQuery = @"exec [CMX_LoginLog_Insert] @UserID=";
                        sqlQuery = sqlQuery + request.UserID.ToString();
                        sqlQuery = sqlQuery + @", @LoginTime='";
                        sqlQuery = sqlQuery + request.LoginTime.ToString();
                        sqlQuery = sqlQuery + @"',@LogoutTime='";
                        sqlQuery = sqlQuery + minValue.ToString();
                        sqlQuery = sqlQuery + @"', @MinutesLoggedIn=0, @DbConnectionName=";
                        CoreContext.Database.ExecuteSqlCommand(sqlQuery);
                        result = this.Ok("Insert LoginLog successfully!");
                    }
                }
            }
            catch (Exception exception)
            {
                WriteLog(exception, "AuthController-InsertLoginLog", LogLevel.Error, false);
                result = this.BadRequest("Insert LoginLog failure!");
            }
            return result;
        }

        /// <summary>
        /// UpdateLoginLog
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="201">Created</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="500">Have Error</response>
        [HttpPost("updateloginlog", Name = nameof(AuthController) + nameof(UpdateLoginLog))]
        public ActionResult UpdateLoginLog([FromBody] UpdateLoginLogRequest request)
        {
            ActionResult result;
            try
            {
                int userID = request.UserID;
                if (request.UserID <= 0)
                {
                    result = this.BadRequest("UserID is invalid");
                }
                else
                {
                    DateTime loginTime = request.LoginTime;
                    if (request.LoginTime.Year == 1)
                    {
                        result = this.BadRequest("LoginTime is invalid");
                    }
                    else
                    {
                        int minutesLoggedIn = request.MinutesLoggedIn;
                        if (request.MinutesLoggedIn < 0)
                        {
                            result = this.BadRequest("MinutesLoggedIn is invalid");
                        }
                        else
                        {
                            DateTime time = DateTime.Now;
                            string strSQL = @"exec [CMX_LoginLog_Update] @UserID=";
                            strSQL = strSQL + request.UserID.ToString();
                            strSQL = strSQL + @", @LoginTime='";
                            strSQL = strSQL + request.LoginTime.ToString();
                            strSQL = strSQL + @"', @LogoutTime='";
                            strSQL = strSQL + time.ToString();
                            strSQL = strSQL + @"', @MinutesLoggedIn=";
                            strSQL = strSQL + request.MinutesLoggedIn.ToString();
                            strSQL = strSQL + @", @DbConnectionName=";
                            CoreContext.Database.ExecuteSqlCommand(strSQL);
                            result = this.Ok("Update LoginLog successfully!");
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                WriteLog(exception, "AuthController-UpdateLoginLog", LogLevel.Error, false);
                result = this.BadRequest("Update LoginLog failure!");
            }
            return result;
        }

        /// <summary>
        /// UpdateOnlineStatus
        /// </summary>
        /// <response code="200">Success</response>
        /// <response code="201">Created</response>
        /// <response code="400">Bad request</response>
        /// <response code="401">Unauthentication</response>
        /// <response code="500">Have Error</response>
        [HttpPost("updateonlinestatus", Name = nameof(AuthController) + nameof(UpdateOnlineStatus))]
        public ActionResult UpdateOnlineStatus([FromBody] UpdateOnlineStatusRequest request)
        {
            ActionResult result;
            try
            {
                if ((request.Username == null) || string.IsNullOrEmpty(request.Username))
                {
                    result = this.BadRequest("Username is invalid");
                }
                else
                {
                    string strSQL = @"exec [CMX_User_UpdateUserOnlineStatus] @UserName=";
                    strSQL = strSQL + request.Username;
                    strSQL = strSQL + @", @UserIsOnlineTimeWindow=0, @IsForceSetStatus=1, @IsSignOn=1,@Today='";
                    strSQL = strSQL + DateTime.Now.ToString();
                    CoreContext.Database.ExecuteSqlCommand(strSQL);
                    result = this.Ok("Username: " + request.Username + " is online");
                }
            }
            catch (Exception exception)
            {
                WriteLog(exception, "AuthController-UpdateOnlineStatus", LogLevel.Error, false);
                result = this.BadRequest("Update online status failure!");
            }
            return result;
        }



        #region private functions
        private string GetCurrentDomainPath()
        {
            DirectoryEntry entry = new DirectoryEntry("LDAP://shbho.shb.vn");
            return ("LDAP://" + entry.Properties["defaultNamingContext"][0].ToString());
        }

        #endregion
    }
}