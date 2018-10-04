using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Constructor_Dep_Inj
{
    public interface IText
    {
        void Print();

    }
    class Format : IText
    {
        public void Print()
        {
            Console.WriteLine("here is text format");
        }
    }
    class ColorFormat : IText
    {
        public void Print()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("here is text format");
        }
    }
    public class Constructorinjection :IText
    {
        private IText _text;
        public Constructorinjection(IText t1)
        {
            this._text = t1;
        }
        public void Print()
        {
            _text.Print();
        }
    }
    class Constructor
    {
        static void Main(string[] args)
        {

            Constructorinjection cs = new Constructorinjection(new Format());
            cs.Print();
            Console.ReadKey();
            Constructorinjection cf = new Constructorinjection(new ColorFormat());
            cf.Print();
            Console.ReadKey();
        }
    }
}
