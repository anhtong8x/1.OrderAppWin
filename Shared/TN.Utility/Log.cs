using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using log4net;
using System.Collections;
using System.Reflection;
using System.Xml;

namespace TN.Utility
{
    public class Log
    {
        static readonly ILog logger = LogManager.GetLogger(typeof(Log));
        //private static readonly log4net.ILog logger = log4net.LogManager.GetLogger("TN.Mobike");
        //static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public static void StartLog()
        {
            XmlDocument log4netConfig = new XmlDocument();
            log4netConfig.Load(File.OpenRead("log4net.config"));
            var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));
            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);
        }


        public static void CloseLog()
        {
            foreach (log4net.Appender.IAppender app in logger.Logger.Repository.GetAppenders())
            {
                app.Close();
            }
        }

        public static void Error(string logtype, string logcontent)
        {
            try
            {
                logger.Error($"{logtype} \t {logcontent}");
            }
            catch
            {
                // ignored
            }
        }

        public static void Info(string logtype, string logcontent)
        {
            try
            {
                logger.Info($"{logtype} \t {logcontent}");
            }
            catch
            {
                // ignored
            }
        }

        public static void Debug(string logtype, string logcontent, string prefix = "Process")
        {
            try
            {
                Task.Run(() => WriteHashLog(logtype, logcontent, prefix)).ConfigureAwait(false);
            }
            catch
            {
                // ignored
            }
        }

        private static void WriteHashLog(string logtype, string logcontent, string prefix)
        {
            try
            {
                logcontent = SimpleDES.Crypt($"{prefix}_{logtype} \t {logcontent}");
                logger.Debug(logcontent);
            }
            catch
            {

            }
        }
    }
}
