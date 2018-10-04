using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomEvents
{
    class Program
    {
        public static void Main(string[] args)
        {
            //Time when method needs to be called
            var DailyTime = "17:43:00";
            var timeParts = DailyTime.Split(new char[1] { ':' });

            var dateNow = DateTime.Now;
            var date = new DateTime(dateNow.Year, dateNow.Month, dateNow.Day,
                       int.Parse(timeParts[0]), int.Parse(timeParts[1]), int.Parse(timeParts[2]));
            Console.WriteLine("Trigger date" + date);
            Console.WriteLine("Current date" + dateNow);
            TimeSpan ts;
            if (date > dateNow)
                ts = date - dateNow;
          
            else
            {
                date = date.AddDays(1);
                ts = date - dateNow;
            }
            Console.WriteLine("Method will be execute in "+ts);
            //waits certan time and run the code
            Task.Delay(ts).ContinueWith((x) => SomeMethod());

            Console.Read();
        }

        static void SomeMethod()
        {
            Console.WriteLine("Method is called.");
        }
    }
}
