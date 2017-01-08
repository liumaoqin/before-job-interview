using System;

namespace Lession5TypeConvertion
{
    class Program
    {
        static void Main(string[] args)
        {
            //隐式转换
            int i = 10;
            long l = i;
            C1 c1 = new C2();

            //显示转换
            double d = 10.05;
            int iFromD = (int)d;
            Console.WriteLine(iFromD);
            C1 c11 = new C1();
            //C2 c2 = (C2)c11;
            try
            {
                C2 c2 = (C2)c11;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(c11 is C1);//true
            Console.WriteLine(c11 is C2);//false

            C2 c22 = c11 as C2;//编译成功,运行成功,无法转换时,返回null.
            Console.WriteLine(c22 == null);//true,降低消耗,只能用于非null类型或引用类型,比如值类型,就不是非null类型

            //int iAs = "s" as int;
            //错误	1	as 运算符必须用于引用类型或可以为 null 的类型(“int”是不可以为 null 值的类型)	E:\极客学院2\ASP.NET工程师\1.初级ASP.NET工程师\2.C#语言基础\4.C#的类型转换\Lession5TypeConvertion\Lession5TypeConvertion\Program.cs	38	23	Lession5TypeConvertion

            Console.WriteLine("------------------------");
            string sFrom1 = i.ToString();
            int iFroms = Convert.ToInt32("10");
            //int iFroms2 = Convert.ToInt32("zilong");//System.FormatException

            int iFrom3 = Int32.Parse("101");
            //int iFrom4 = Int32.Parse("zilong");//System.FormatException

            int iFrom5;
            bool succeed = Int32.TryParse("zilong", out iFrom5);
            Console.WriteLine(iFrom5);//0
            //IConvertible,TypeConverter

            Console.WriteLine("------------------------");
            int iToBoxing = 100;
            object iBoxed = iToBoxing;

            int iUnBoxing = (int)iBoxed;
            object nullOjbect = iFrom5;
            int iNUll = (int)nullOjbect;

            int? iNUllable = null; // = null;
            System.Nullable<int> iNUllable2 = 100;//和上一句等价
            //Console.WriteLine(iNUllable.Value);
            Console.WriteLine(iNUllable.HasValue);
            Console.WriteLine(iNUllable.GetValueOrDefault());
            Console.WriteLine(iNUllable2.GetValueOrDefault());

            int iii = iNUllable ?? 999;
            int iiii = iNUllable2 ?? 999;
            Console.WriteLine(iii);
            Console.WriteLine(iiii);

            Console.ReadLine();
        }
    }
    class C1
    { }
    class C2 : C1
    { }
}