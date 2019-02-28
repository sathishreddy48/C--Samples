using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterviewQuestions
{
    public  class MyClass : IInterface
    {
        public static string s;
        const string ss="Satheesh";
        private string mvalue;
        public string MyProperty
        {
            get
            {
                return mvalue;
            }

            set
            {
                mvalue = value;
            }
        }
    }
    public interface IInterface
    {

        string MyProperty { set; get; }
    }

    class Program 
    {
        static void Main(string[] args)
        {
            MyClass.s = "sa";
            Console.WriteLine(MyClass.s);
            MyClass.s = "Reddy";
            Console.WriteLine(MyClass.s);
            MyClass my = new MyClass
            {
                MyProperty = "property"
            };
            Console.WriteLine(my.MyProperty);
            Console.ReadKey();
        }
    }
}
