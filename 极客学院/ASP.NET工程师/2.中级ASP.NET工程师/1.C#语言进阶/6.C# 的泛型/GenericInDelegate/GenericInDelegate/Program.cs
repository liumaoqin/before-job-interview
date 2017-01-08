using System;

namespace GenericInDelegate
{
    delegate T NumberChange<T>(T n);//Event,interface
    class Program
    {
        static int num = 0;
        public static int AddNum(int p)
        {
            num += p;
            return num;
        }
        public static int MultiNum(int p)
        {
            num *= p;
            return num;
        }
        static void Main(string[] args)
        {
            NumberChange<int> nc1 = new NumberChange<int>(AddNum);
            NumberChange<int> nc2 = new NumberChange<int>(MultiNum);
            nc1(25);
            Console.WriteLine(num);
            nc2(5);
            Console.WriteLine(num);

            Console.ReadLine();
        }
    }
}
