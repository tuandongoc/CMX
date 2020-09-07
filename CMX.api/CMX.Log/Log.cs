using CMX.Logging.Extensions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace CMX.Logging
{
    public static class Log
    {
        public static void Writelog(ILogger logger, Exception ex, string message, LogLevel logLevel, bool willNotify = false)
        {
            //var serviceProvider = new ServiceCollection()
            //  .AddLogging(builder => builder.AddLog4Net("log4net.config"))
            //  .BuildServiceProvider();

            //process Notify
            if (willNotify)
            {
                //call Notify api
                //try
                //{
                //    Notify.SendEmailAsync("INes.Logger", message, "tuandongoc.hut@gmail.com").Wait();
                //}
                //catch(Exception _ex)
                //{
                //    WriteLogException(_ex);
                //}
            }

            //process Logger
            if (logLevel == LogLevel.Information)
            {
                WriteLogInfo(logger, ex, message);
            }
            else if (logLevel == LogLevel.Debug)
            {
                WriteLogDebug(logger, ex, message);
            }
            else if (logLevel == LogLevel.Error)
            {
                WriteLogException(ex);
            }
        }


        #region Public functions

        public static void SetLoggerFactory(ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
            _logger = _loggerFactory?.CreateLogger("CMX.Logger");

        }


        /// <summary>
        /// Method write log for all the exception object
        /// </summary>
        /// <param name="ex">Exception object</param>
        public static void LogException(this Exception ex)
        {
            //process exception

            logException(ex);
        }

        /// <summary>
        /// Method write log for all the exception object
        /// </summary>
        /// <param name="ex">Exception object</param>
        public static void LogException(this object obj, Exception ex)
        {
            logException(ex, obj);
        }
        /// <summary>
        /// Method write log info for all the exception object
        /// </summary>
        /// <param name="obj">Object to write log</param>
        /// <param name="message">Log Message</param>
        public static void LogError(this object obj, string message)
        {
            logError(message);
        }
        /// <summary>
        /// Method write log debug for all the exception object
        /// </summary>
        /// <param name="obj">Object to write log</param>
        /// <param name="message">Log Message</param>
        public static void LogDebug(this object obj, string message)
        {
            logDebug(message);
        }

        /// <summary>
        /// Method write log info for all the exception object
        /// </summary>
        /// <param name="obj">Object to write log</param>
        /// <param name="message">Log Message</param>
        public static void LogInfo(this object obj, string message)
        {
            logInfo(message);
        }

        /// <summary>
        /// Write exception log
        /// </summary>
        /// <param name="ex">Exception object</param>
        public static void WriteLogException(Exception ex)
        {
            logException(ex);
        }

        /// <summary>
        /// Method write log debug for all the exception object
        /// </summary>
        /// <param name="obj">Object to write log</param>
        /// <param name="message">Log Message</param>
        public static void WriteLogDebug(ILogger logger, object obj, string message)
        {
            if (logger != null)
            {
                logger.LogDebug(message);
            }
            else
            {
                logDebug(message);
            }

        }

        /// <summary>
        /// Method write log info for all the exception object
        /// </summary>
        /// <param name="logger">Log</param>
        /// <param name="obj">Object to write log</param>
        /// <param name="message">Log Message</param>
        public static void WriteLogInfo(ILogger logger, object obj, string message)
        {
            if (logger != null)
            {
                logger.LogInformation(message);
            }
            else
            {
                logInfo(message);
            }

        }

        #endregion

        #region private functions

        private static ILoggerFactory _loggerFactory;
        private static ILogger _logger;

        private static void logException(Exception ex, object obj = null)
        {
            _logger?.LogError(ex, "CMX Exception", obj);
        }

        public static void logDebug(string message, object obj = null)
        {
            _logger?.LogDebug(message, obj);
        }

        public static void logInfo(string message, object obj = null)
        {
            _logger?.LogInformation(message);
        }

        public static void logError(string message, object obj = null)
        {
            _logger?.LogError(message, obj);
        }

        #endregion
    }
}
