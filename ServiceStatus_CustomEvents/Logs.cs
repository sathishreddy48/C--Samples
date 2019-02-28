using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC.CPLS.DELTA.CD.DELTA_Health_Scheduler
{
  public  class Logs
    {
        private static object lockObject = new object();
        DateTime date = DateTime.Now;
        //String Path = ConfigurationManager.AppSettings["PathDeploymentServiceLogFile"];
        //D:\Delta2.0_Sample_Logs\Dev
        String Path = @"D:\Delta2.0_Sample_Logs\Dev\Test.txt";
        static void Main(string[] args)
        {
            int x = 50;
            Logs logs = new Logs();
           while (x<51)
            {
                if(x/2==0)
                {
                    logs.LogError("         LogError          ");
                    System.Console.WriteLine("LogError");
                }
                else
                {
                    logs.LogInfo("          LogInfo           ");
                    System.Console.WriteLine("LogInfo");
                }
                System.Threading.Thread.Sleep(2*60*1000);
            }
            System.Console.WriteLine("Exiting");
        }
        public void LogError(string message)
        {
            lock (lockObject)
            {
                File.AppendAllText(Path, String.Format(Environment.NewLine + $"ERROR! {date:yyyy-MM-dd HH:mm:ss} : { message}"));
            }
        }

        public void LogInfo(string message)
        {
            lock (lockObject)
            {
                File.AppendAllText(Path, String.Format(Environment.NewLine + $"INFO ! {date:yyyy-MM-dd HH:mm:ss} : { message}"));
            }
        }
    }
}
