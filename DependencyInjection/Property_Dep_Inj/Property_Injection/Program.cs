using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Property_Injection
{
    public interface INofificationAction
    {
        void ActOnNotification(string message);
    }
    class Notification
    {
        INofificationAction task = null;
        public void notify(INofificationAction at, string messages)
        {
            this.task = at;
            task.ActOnNotification(messages);
        }
    }
    class EventLogWriter : INofificationAction
    {
        public void ActOnNotification(string message)
        {
            // Write to event log here  
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            EventLogWriter elw = new EventLogWriter();
            Notification notification = new Notification();
            notification.notify(elw, "to logg");
            Console.ReadKey();
        }
    }
}
