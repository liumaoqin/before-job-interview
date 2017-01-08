using System;
using System.Text;

namespace lession3
{
    class Program
    {
        static void Main(string[] args)
        {
            // object,string dynamic
            // System.Object,System.String,System.Dynamic(在程序的运行阶段,其他是编译阶段)
            object o = new object();
            object o2 = new Object(); // System.Ojbect;

            Console.WriteLine(o.GetType());
            Console.WriteLine(o.ToString());
            int i = 5;
            Console.WriteLine(i.ToString());

            string s = "zilong";
            string s2 = "zi";
            s2 += "long";
            Console.WriteLine(s);
            Console.WriteLine(s2);
            Console.WriteLine(s == s2);
            Console.WriteLine((object)s == (object)s2);
            char c = s[2];
            Console.WriteLine(c);
            string u = "\\\u0066\n";
            Console.WriteLine(u);
            string at = @"E:\zilong\ASP.NET工程师\1.初级ASP.NET工程师\2.C#语言基础\3.C#的引用类型";
            Console.WriteLine(at);
            string noAt = "E:\\zilong\\ASP.NET工程师\\1.初级ASP.NET工程师\\2.C#语言基础\\3.C#的引用类型";
            Console.WriteLine(noAt);
            at.Contains("zilong");
            Console.WriteLine(at.Length);
            Console.WriteLine(at.IndexOf("zi"));

            StringBuilder builder = new StringBuilder();
            builder.Append("zi");
            builder.Append("long");
            Console.WriteLine(builder.ToString());
            builder.AppendFormat(" hello {0} {1}", "zilong", "world");
            Console.WriteLine(builder.ToString());

            Console.ReadLine();
        } 
    }
}
