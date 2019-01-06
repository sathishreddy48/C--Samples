using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    class Program
    {
        static void Main(string[] args)
        {
            ISet<int> setofnos = new HashSet<int> { 1, 2 };
            setofnos.Add(3);
            setofnos.Add(2);
            foreach (var el in setofnos)
                Console.WriteLine(el);
            Console.ReadKey();
        }
    }
}
