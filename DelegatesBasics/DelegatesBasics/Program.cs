using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesBasics
{
    class Program
    {
        public delegate int Squareof(int x);
        public int Productof(int x)
        {
            return x * x;
        }
        public int Sumof(int x)
        {
            return x + x;
        }
        public static int Result(Squareof squareof, int x)
        {
            return squareof(x);
        }

        static void Main(string[] args)
        {
            Program program = new Program();

            Console.WriteLine("Product of 5*5 is " + Result(program.Productof, 5));
            Console.WriteLine("Sum of 5+5 is " + Result(program.Sumof, 5));
            Console.ReadKey();
        }
    }
}

