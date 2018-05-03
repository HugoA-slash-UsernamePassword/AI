using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates
{
    class Program
    {
        public delegate void Func();
        public static int count = 0;

        static void PrintName()
        {
            count++;
            Console.Write((char)count);
        }

        static void Main(string[] args)
        {
            Func myFunction = new Func(PrintName);

            for (int i = 0; i < 999; i++)
            {
                myFunction += PrintName;
                myFunction.Invoke();
                Console.Write("");
            }
            Console.ReadLine();
        }
    }
}
