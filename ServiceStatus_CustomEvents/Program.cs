using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.ServiceProcess;


namespace EC.CPLS.DELTA.CD.DELTA_Health_Scheduler
{
    public class ServicechangeEventArgs : EventArgs
    {
        public ServiceChangeStatus _ServiceChangeStatus;
        public ServicechangeEventArgs(ServiceChangeStatus serviceChangeStatus)
        {
            this._ServiceChangeStatus = serviceChangeStatus;
        }
    }
    public class ServiceChangeStatus
    {

        private string _ServiceName;
        ServiceControllerStatus _serviceStatus;
        public DateTime StatusChangedTime;
        public ServiceChangeStatus(string name, ServiceControllerStatus status)
        {
            _ServiceName = name;
            _serviceStatus = status;
            StatusChangedTime = DateTime.Now;
        }
        public string ServiceName
        {
            get
            {
                return _ServiceName;
            }
        }
        public ServiceControllerStatus serviceStatus
        {
            get
            {
                return _serviceStatus;
            }
        }
    }

    //Customized events 

    public class ServiceMonitor
    {
        //Creating delegate
        public delegate void ServiceStatusChangeEventRaiser(ServicechangeEventArgs servicechangeEventArgs);

        /// <summary>
        /// Creating Event for corresponding delegate
        /// </summary>
        public event ServiceStatusChangeEventRaiser OnServiceStatusChange;

        public void CheckStatus(string ServiceName)
        {
            ServiceController sc = new ServiceController(ServiceName);
            var Service_ctrl = ServiceController.GetServices().FirstOrDefault(s => s.ServiceName == ServiceName);
            //Console.WriteLine(Service_ctrl.Status);
            if (Service_ctrl != null)
            {
                if ((Service_ctrl.Status != ServiceControllerStatus.Running) && (OnServiceStatusChange != null))
                {
                    ServiceChangeStatus serviceChangeStatus = new ServiceChangeStatus(ServiceName, Service_ctrl.Status);
                    ServicechangeEventArgs servicechangeEventArgs = new ServicechangeEventArgs(serviceChangeStatus);
                    OnServiceStatusChange(servicechangeEventArgs);
                }
            }
            else
            {
                //Service not Available
            }

        }

    }
    class Program
    {
        static void Main()
        {
            ServiceMonitor serviceMonitor = new ServiceMonitor();
            serviceMonitor.OnServiceStatusChange += new ServiceMonitor.ServiceStatusChangeEventRaiser(LogServiceStatusChanged);
            serviceMonitor.OnServiceStatusChange += new ServiceMonitor.ServiceStatusChangeEventRaiser(SentEmailOnServiceStopped);
            serviceMonitor.CheckStatus("PlugPlay");
            System.Threading.Thread.Sleep(30 * 1000);
            serviceMonitor.CheckStatus("PlugPlay");
            System.Threading.Thread.Sleep(30 * 1000);
            serviceMonitor.CheckStatus("PlugPlay");
            Console.ReadKey();
        }

        static void LogServiceStatusChanged(ServicechangeEventArgs Orgs)
        {
            if (Orgs._ServiceChangeStatus.serviceStatus != ServiceControllerStatus.Running)
            {
                Console.WriteLine("Service Not Running ");
               // SentEmailOnServiceStopped(Orgs._ServiceChangeStatus.ServiceName, "Stopped");
            }
            else
            {
                Console.WriteLine("Service Status Not Changed");
            }
        }
        static void SentEmailOnServiceStopped(ServicechangeEventArgs eventArgs)
        {
            if (eventArgs._ServiceChangeStatus.serviceStatus != ServiceControllerStatus.Running)
            {
                Console.WriteLine("Service Not Running ");
                using (var smtpClient = new SmtpClient())
                {
                    NetworkCredential networkCredential;
                    smtpClient.Host = "smtp-mail.outlook.com";
                    smtpClient.Port = 587;
                    smtpClient.UseDefaultCredentials = false;
                    networkCredential = new NetworkCredential("cpla-tra@microsoft.com", "Tr@c345ucc355!!");
                    smtpClient.EnableSsl = true;
                    smtpClient.Credentials = networkCredential;
                    MailAddress frommailAddress = new MailAddress("cpla-tra@microsoft.com", "DELTA Team");
                    MailMessage mailMessage = new MailMessage()
                    {
                        SubjectEncoding = Encoding.UTF8,
                        Body = eventArgs._ServiceChangeStatus.ServiceName + " Service  is Not Running" ,
                        BodyEncoding = Encoding.UTF8,
                        IsBodyHtml = true
                    };
                    mailMessage.From = frommailAddress;
                    mailMessage.Subject = "DELTA 2.0 Health";
                    mailMessage.To.Add("v-satheg@microsoft.com");
                    mailMessage.To.Add("v-mamula@microsoft.com");
                    mailMessage.To.Add("v-anpans@microsoft.com");
                    mailMessage.To.Add("v-devepa@microsoft.com");
                    smtpClient.Send(mailMessage);
                }
            }
            else
            {
                Console.WriteLine("Service Status Not Changed");
            }
           
        }
    }
    //    Stopped = 1,
    //    StartPending = 2,
    //    StopPending = 3,
    //    Running = 4,
    //    ContinuePending = 5,
    //    PausePending = 6,
    //    Paused = 7
}

