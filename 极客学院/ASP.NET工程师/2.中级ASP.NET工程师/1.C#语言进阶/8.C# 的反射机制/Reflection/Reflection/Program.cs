using System;

namespace Reflection
{
    using System.Reflection;
    class Program
    {
        static void Main(string[] args)
        {
            //之前的 typeof
            //object.GetType();
            string s = "Hello Reflection";
            Type t = s.GetType();
            Console.WriteLine(t.FullName);

            //Type.GetType("System.String");
            Type t2 = Type.GetType("System.String", false, true);
            Console.WriteLine(t2.FullName);

            //typeof
            Type t3 = typeof(String);
            Console.WriteLine(t3.FullName);

            //Type 为 System.Type 抽象类不能实例化
            //FullName,BaseType,IsAbstract,IsClass,IsMethod,IsArray
            //GetConstructors();GetEvent();GetField();GetMember();GetProperty();

            Console.WriteLine("------------------------");
            //GetMethods(t);
            Console.WriteLine("Jion Method:{0}", t.GetMethod("Copy"));
            Console.WriteLine("------------------------");
            GetMethods(t, BindingFlags.Public | BindingFlags.Instance);
            //GetFields();GetPropertes(); //获得所有的属性

            Console.ReadLine();
        }
        public static void GetMethods(Type t,BindingFlags f)
        {
            MethodInfo[] mi = t.GetMethods(f);
            foreach(var item in mi)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
