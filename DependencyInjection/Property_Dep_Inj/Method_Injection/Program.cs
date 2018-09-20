using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Method_Injection
{
       public interface IPrinter
        {
            void Print();
        }
        public class PrinterService : IPrinter
       {
            public void Print()
            {
                Console.WriteLine("print........");
            }
        }
        public class client
        {
            private IPrinter _set;
            public void Print(PrinterService serv)
            {
                this._set = serv;
                Console.WriteLine("start");
                this._set.Print();
            }
        }
        class method
        {
            public static void Main()
            {
                client cn = new client();
                cn.Print(new PrinterService());
                Console.ReadKey();
            }
        }
    }


