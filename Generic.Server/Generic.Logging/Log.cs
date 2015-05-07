using Generic.Util;
using NLog;
using System;
using System.Collections.Generic; 
using System.Text; 

namespace Generic.Logging
{
    public class Log : Singleton<Log>
    {
        private static Logger genericlogger;
        private static Logger growllogger;
        private static Logger consolelogger; 

        public static Logger Logger
        {
            get { return genericlogger; }
        }

        public Log()
        {
            growllogger = LogManager.GetLogger("growl");
            genericlogger = LogManager.GetLogger("generic");
            consolelogger = LogManager.GetLogger("console");
        }

        public static void Trace(Exception ex)
        {
            Trace("[EXCEPTION] " + ex);
        }

        public static void Info(Exception ex)
        {
            Info("[EXCEPTION] " + ex);
        }

        public static void Warn(Exception ex)
        {
            Warn("[EXCEPTION] " + ex);
        }

        public static void Error(Exception ex)
        {
            Error("[EXCEPTION] " + ex);
        }

        public static void Fatal(Exception ex)
        {
            Fatal("[EXCEPTION] " + ex);
        }

        public static void Debug(Exception ex)
        {
            Debug("[EXCEPTION] " + ex);
        } 

        public static void Trace(string message)
        {
            I.Output(LogLevel.Trace, message);
        }

        public static void Info(string message)
        {
            I.Output(LogLevel.Info, message);
        }

        public static void Warn(string message)
        {
            I.Output(LogLevel.Warn, message);
        }

        public static void Error(string message)
        {
            I.Output(LogLevel.Error, message);
        }

        public static void Fatal(string message)
        {
            I.Output(LogLevel.Fatal, message);
        }

        public static void Debug(string message)
        {
            I.Output(LogLevel.Debug, message);
        }

        private void Output(LogLevel type, string message)
        {
            genericlogger.Log(type, message);  
            growllogger.Log(type, message);  
            consolelogger.Log(type, message);  
        }
    }
}
