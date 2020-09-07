using CMX.Logging.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CMX.api.Settings
{
    public class AdvancedConfiguration
    {
        /// <summary>
        /// Config Microsoft.Extensions.Logging.Log4Net.AspNetCore
        /// </summary>
        /// <param name="configuration">interface configuration/param>
        /// <param name="loggerFactory">interface logger Factory</param>
        /// <param name="logger">interface logger </param>
        /// <param name="configFilepath">Config file Path</param>
        /// <param name="configNode">Log setting in net core</param>
        public static void ConfigLog4net(IConfiguration configuration, ILoggerFactory loggerFactory, string configFilepath, string configNode)
        {
            loggerFactory.AddLog4Net(configFilepath, configuration);
            CMX.Logging.Log.SetLoggerFactory(loggerFactory);
        }
    }
}
