using System;

namespace MultiCasingDelegate
{
    delegate void D(int i);
    class Program
    {
        static void Main(string[] args)
        {
            D cd1 = new D(C.M1);
            cd1(-1);
            Console.WriteLine();
            D cd2 = new D(C.M2);
            cd2(-2);
            Console.WriteLine();

            //委托有一个按顺序的调用列表(类似Stack)
            D cd3 = cd1 + cd2;
            cd3(-3);
            Console.WriteLine();

            C c = new C();
            D cd4 = new D(c.M3);
            cd3 += cd4;
            cd3(-9);
            Console.WriteLine();

            cd3 += cd1;
            cd3(-9);
            Console.WriteLine();
            cd3 -= cd1; 
            cd3(-9);
            Console.WriteLine();

            cd3 -= cd4;
            cd3 -= cd2;
            cd3 -= cd2;
            //cd3 -= cd1;
            if(cd3 != null)//避免空引用异常
            {
                cd3(77);
            }
            cd3 -= cd1;
            //即使空了之后一样可以编译和运行,但该操作是无效的
            cd3 -= cd1;

            Console.ReadLine();
        }
    }
    class C
    {
        public static void M1(int p)
        {
            Console.WriteLine("M1 : {0}", p);
        }
        public static void M2(int p)
        {
            Console.WriteLine("M2 : {0}", p);
        }
        public void M3(int p)
        {
            Console.WriteLine("M3 : {0}", p);
        }
    }
}
