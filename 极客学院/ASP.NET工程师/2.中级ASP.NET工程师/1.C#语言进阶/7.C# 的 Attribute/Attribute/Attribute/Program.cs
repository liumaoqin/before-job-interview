#define DEBUG
using System;
using System.Diagnostics;

namespace Attribute
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass.Message("In Main Function");
            Function1();
            Console.ReadLine();
        }
        //警告	1	“Attribute.Program.Function1()”已过时:“Don't user old Method”
        [Obsolete("Don't user old Method")]
        static void Function1()
        {
            MyClass.Message("In Function1");
            Function2();
        }
        static void Function2()
        {
            MyClass.Message("In Function2");
        }
    }
    public class MyClass
    {
        [Conditional("DEBUG")]
        public static void Message(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
