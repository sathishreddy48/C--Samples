using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialInvocation
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //partial invocation method
            Func<int, int, int> AddSome = (valueToAdd, value) => value + valueToAdd;

            SomeClass someClass = new SomeClass(2);
            Console.WriteLine(someClass.AddSome(5));

            // partial invocation
            var result = AddSome(2, 1);
           // var result2 = AddSome(2);
            Console.WriteLine(result);
            Console.ReadKey();
        }
      
    }
    public sealed class SomeClass
    {
        public readonly int valueToAdd;
        public SomeClass(int valueToAdd)
        {
            this.valueToAdd = valueToAdd;
           
        }
        public int AddSome(int value) => value + valueToAdd;
    }
}
