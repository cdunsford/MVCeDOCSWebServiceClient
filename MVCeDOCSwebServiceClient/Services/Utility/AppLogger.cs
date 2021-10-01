using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCeDOCSwebServiceClient.Services.Utility
{
    public class AppLogger : ILogger
    {
        //This class is used to create a singleton of the logger to avoid threading issues in logging

        private static AppLogger instance;
        private static Logger logger;

        //private constructor so that the AppLogger class can only be instantiated by itself through GetInstance method
        private AppLogger()
        {

        }

        public static AppLogger GetInstance()
        {
            if(instance == null)
            {
                instance = new AppLogger();

            }

            return instance;

        }

        private Logger GetLogger(string theLogger)
        {
            if(AppLogger.logger == null)
            {
                AppLogger.logger = LogManager.GetLogger(theLogger);

            }

            return AppLogger.logger;
        }




        public void Debug(string message, string arg = null)
        {
            if(arg == null)
            {
                GetLogger("myAppLoggerRules").Debug(message);
            }
            else
            {
                GetLogger("myAppLoggerRules").Debug(message,arg);
            }
        }

        public void Error(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("myAppLoggerRules").Error(message);
            }
            else
            {
                GetLogger("myAppLoggerRules").Error(message, arg);
            }
        }

        public void Info(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("myAppLoggerRules").Info(message);
            }
            else
            {
                GetLogger("myAppLoggerRules").Info(message, arg);
            }
        }

        public void Warning(string message, string arg = null)
        {
            if (arg == null)
            {
                GetLogger("myAppLoggerRules").Warn(message);
            }
            else
            {
                GetLogger("myAppLoggerRules").Warn(message, arg);
            }
        }
    }
}