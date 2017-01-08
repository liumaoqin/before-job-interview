using System;

namespace Anonymous
{

    class Program
    {
        delegate void TestDelegate(string s);
        delegate int del(int i);
        delegate TResult Func<TArg0, TResult>(TArg0 arg0);
        static void M(string s)
        {
            Console.WriteLine(s);
        }
        static void Main(string[] args)
        {
            DelegateHistory();
            StartThread();
            lambda();

            Console.ReadLine();
        }
        private static void DelegateHistory()
        {
            TestDelegate testDelA = new TestDelegate(M);

            // C# 2.0 Anonymous Method
            TestDelegate testDelB = delegate(string s) { Console.WriteLine(s); };

            // C# 3.0 lambda Expression
            TestDelegate testDelC = (x) => { Console.WriteLine(x); };

            testDelA("Hello. this is a delegate");
            testDelB("This is a anonymous method");
            testDelC("This is a lamba expression");
        }
        private static void StartThread()
        {
            System.Threading.Thread t1 = new System.Threading.Thread(
                delegate()//not allow "ref out" keyword and unsafe code
                {
                    System.Console.Write("hello, ");
                    System.Console.WriteLine("world!");
                }
            );
            t1.Start();
        }
        public static void lambda()
        {
            // () => Expression
            del myDelegate = x => x * x;//只有一个参数的是否可以不写括号
            del myDelegate2 = (x) => { x = x + 2; return  x * x; };

            Func<int, bool> myFunc = x => x == 5;
            Console.WriteLine(myFunc(10));
        }
    }
}
