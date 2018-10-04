using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency
{
    public interface text
    {
        void Print();
    }
    class format : text
    {
        public void Print()
        {

            Console.WriteLine(" here is text format");

        }

    }
    // constructor injection  
    public class constructorinjection
    {

        private text _text;
        public constructorinjection(text t1)
        {
            this._text = t1;

        }
        public void print()
        {

            _text.Print();
        }





    }
    class constructor
    {
      
        static void Main(string[] args)
        {

            //constructorinjection cs = new constructorinjection(new format());
            //cs.print();
            string ReleaseVehicleStartDate = DateTime.Now.ToShortDateString();
            string s = "Below deployment scripts are tagged Release Vehicle which Starts from {ReleaseVehicleStartDate}";

            // string ss = $"" + string.Format(s,ReleaseVehicleStartDate,ReleaseVehicleStartDate);
            Console.Write("$"+s);

            Console.ReadKey();

        }
    }
}
