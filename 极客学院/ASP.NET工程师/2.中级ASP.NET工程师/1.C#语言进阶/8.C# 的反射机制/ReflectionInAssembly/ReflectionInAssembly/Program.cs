using System;
using System.Reflection;

namespace ReflectionInAssembly
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly objAssembly;
            objAssembly = Assembly.Load("mscorlib,2.0.0.0.Neutral,b77a5c561934e089");

            //late binding 推迟绑定
            Type[] types = objAssembly.GetTypes();
            //foreach(var item in types)
            //{
            //    Console.WriteLine(item.FullName);
            //}

            objAssembly = Assembly.GetExecutingAssembly();//很重要的一句
            Type t = objAssembly.GetType("ReflectionInAssembly.Car", false, true);
            object obj = Activator.CreateInstance(t);
            MethodInfo m1 = t.GetMethod("IsMoving");
            var isMoving = (bool)m1.Invoke(obj,null);
            Console.WriteLine("is Moving : {0}",isMoving);
            //System.Emmit();//在运行时创建新的类型,并实例化它,运行它

            Console.ReadLine();
        }
    }
    public class Car
    {
        public bool IsMoving()
        {
            return true;
        }
    }
}
