using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using EC.CPLA.DELTA.CD.Repository.Interfaces;
using System.Configuration;

namespace EC.CPLA.DELTA.CD.Repository.Utilities
{
    public interface ILog
    {
        void LogError(string message);
        void LogInfo(string message);
    }
    public class DeploymentServiceLogger : ILog
    {
        private static object lockObject = new object();
        DateTime date = DateTime.Now;
        String path = ConfigurationManager.AppSettings["PathDeploymentServiceLogFile"];
        public DeploymentServiceLogger()
        {
            var FileName=Path.GetFileName(path);
            var Prefix = String.Format("{0:M_d_yyyy_}", date);
            path = Path.GetDirectoryName(path) + "\\" + Prefix + FileName;
            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }
        public void LogError(string message)
        {
            lock (lockObject)
            {
                File.AppendAllText(path, String.Format(Environment.NewLine + $"ERROR! {date:yyyy-MM-dd HH:mm:ss} : { message}"));
            }            
        }

        public void LogInfo(string message)
        {
            lock (lockObject)
            {
                File.AppendAllText(path, String.Format(Environment.NewLine + $"INFO ! {date:yyyy-MM-dd HH:mm:ss} : { message}"));
            }            
        }
    }
    public class TaggingServiceLogger : ILog
    {
        private static object lockObject = new object();
        DateTime date = DateTime.Now;
        String path = ConfigurationManager.AppSettings["PathTaggingServiceLogFile"];
        public TaggingServiceLogger()
        {
            var FileName = Path.GetFileName(path);
            var Prefix = String.Format("{0:M_d_yyyy_}", date);
            path = Path.GetDirectoryName(path) + "\\" + Prefix + FileName;
            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }
        public void LogError(string message)
        {
            lock (lockObject)
            {
                File.AppendAllText(path, String.Format(Environment.NewLine + $"ERROR! {date:yyyy-MM-dd HH:mm:ss} : { message}"));
            }            
        }

        public void LogInfo(string message)
        {
            lock(lockObject)
            {
                File.AppendAllText(path, String.Format(Environment.NewLine + $"INFO ! {date:yyyy-MM-dd HH:mm:ss} : { message}"));
            }            
        }
    }
    public class EmailNotificationServiceLogger : ILog
    {
        private static object lockObject = new object();
        DateTime date = DateTime.Now;
        String path = ConfigurationManager.AppSettings["PathEmailNotificationServiceLogFile"];
        public EmailNotificationServiceLogger()
        {
            var FileName = Path.GetFileName(path);
            var Prefix = String.Format("{0:M_d_yyyy_}", date);
            path = Path.GetDirectoryName(path) + "\\" + Prefix + FileName;
            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }
        public void LogError(string message)
        {
            lock (lockObject)
            {
                File.AppendAllText(path, String.Format(Environment.NewLine + $"ERROR! {date:yyyy-MM-dd HH:mm:ss} : { message}"));
            }            
        }

        public void LogInfo(string message)
        {
            lock (lockObject)
            {
                File.AppendAllText(path, String.Format(Environment.NewLine + $"INFO ! {date:yyyy-MM-dd HH:mm:ss} : { message}"));
            }            
        }
    }
    public  class LoggerUtilities  :ILog
    {
        private ILog _logger;
        public LoggerUtilities(ILog logger)
        {
            _logger = logger;
        }
        public void LogInfo(string message)
        {
            _logger.LogInfo(message);
        }
        public void LogError(string message)
        {
            _logger.LogError(message);
        } 
    }
}
