using System;

namespace Delegate
{
    delegate int NumberChanger(int p);
    class Program
    {
        static int num = 10;
        static void Main(string[] args)
        {
            //System.Delegate delegate
            NumberChanger change = new NumberChanger(AddNum);
            change(20);
            Console.WriteLine("value of num: {0}", num);

            //实例方法的委托
            Console.WriteLine("------------------------------");
            MyClass mc = new MyClass();
            NumberChanger change2 = new NumberChanger(mc.AddNum);
            change2(120);
            Console.WriteLine("value of instance num:{0}", mc.num);
            
            NumberChanger change3 = new NumberChanger(mc.MultiNum);
            change3(2);
            Console.WriteLine("value of instance num:{0}", mc.num);

            Console.ReadLine();
        }
        public static int AddNum(int p)
        {
            num += p;
            return num;
        }
    }
    class MyClass
    {
        public int num = 10;

        public int AddNum(int p)
        {
            num += p;
            return num;
        }
        public int MultiNum(int p)
        {
            num *= p;
            return num;
        }
    }
}
