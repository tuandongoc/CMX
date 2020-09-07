using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CMX.Logging.Extensions
{
   public static class Log4NetLoggerFactoryExtensions {
      public static ILoggingBuilder AddLog4Net(this ILoggingBuilder builder) {
         builder.SetMinimumLevel(LogLevel.Warning);
         builder.AddProvider(CreateLog4NetProvider(null));

         return builder;
      }

      public static ILoggingBuilder AddLog4Net(this ILoggingBuilder builder, string configFileName) {
         builder.SetMinimumLevel(LogLevel.Trace);
         builder.AddProvider(CreateLog4NetProvider(configFileName));

         return builder;
      }

      public static ILoggerFactory AddLog4Net(this ILoggerFactory factory) {
         factory.AddProvider(CreateLog4NetProvider(null));

         return factory;
      }

      public static ILoggerFactory AddLog4Net(this ILoggerFactory factory, string configFileName, IConfiguration configuration) {
         factory.AddProvider(CreateLog4NetProvider(configFileName));
            Notify.SetConfig(configuration);

            

            return factory;
      }


        private static ILoggerProvider CreateLog4NetProvider(string configFileName) {
         var fileName = string.IsNullOrEmpty(configFileName) ? "log4net.config" : configFileName;

         return new Log4NetLoggerProvider(fileName);
      }
   }
}
