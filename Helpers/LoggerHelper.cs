using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using NLog;
using NLog.Web;

namespace GestionConsultorio.Helpers
{
    public class LoggerHelper : ILoggerHelper
    {
        public Logger logger;

        public LoggerHelper()
        {
            var configuringFileName = "nlog.config";

            //If we inspect the Hosting aspnet code, we'll see that it internally looks the 
            //ASPNETCORE_ENVIRONMENT environment variable to determine the actual environment
            var aspnetEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var environmentSpecificLogFileName = $"nlog.{aspnetEnvironment}.config";

            if (File.Exists(environmentSpecificLogFileName))
            {
                configuringFileName = environmentSpecificLogFileName;
            }
            logger = NLogBuilder.ConfigureNLog(configuringFileName).GetCurrentClassLogger();
        }

        public void logError(Exception e)
        {
            logger.Error(e);
        }
    }

    public interface ILoggerHelper
    {
        void logError(Exception e);
    }
}
