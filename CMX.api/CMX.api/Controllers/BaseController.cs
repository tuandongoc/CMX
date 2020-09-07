using CMX.Entities.Models.Core;
using CMX.Entities.Models.Works;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMX.api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class BaseController: Controller
    {
        protected readonly ILogger _logger;
        protected CWorksContext WorksContext;
        protected CoreContext CoreContext;

        /// <summary>
        /// 
        /// </summary>
        public BaseController(CWorksContext context, IConfiguration configuration, ILogger<BaseController> logger)
        {
            WorksContext = context;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        public BaseController(CWorksContext context, CoreContext coreContext, IConfiguration configuration, ILogger<BaseController> logger)
        {
            WorksContext = context;
            CoreContext = coreContext;
            _logger = logger;
        }

        /// <summary>
        /// 
        /// </summary>
        protected void WriteLog(string message)
        {
            CMX.Logging.Log.Writelog(_logger, null, message, LogLevel.Debug, false);
        }

        /// <summary>
        /// 
        /// </summary>
        protected void WriteLog(Exception ex, string message, LogLevel logLevel, bool willNotify)
        {
            CMX.Logging.Log.Writelog(_logger, ex, message, logLevel, willNotify);
        }
    }
}
