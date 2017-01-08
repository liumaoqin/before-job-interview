using Lession7EncapsulationAnother;
using System;
using AnotherAssembly;

namespace Lession7Encapsulation
{
    class Program
    {
        static void Main(string[] args)
        {
            //public,private,internal,protected,internal protected

            //public 对外开放
            //private 对外不开放
            Person person = new Person();
            Console.WriteLine(person.GetAge());

            //internal 对同一个Assembly(程序集)开放
            //assembley vs namespace,一个assembly里可以声明多个命名空间
            //物理的包vs逻辑的概念
            AnotherNamespaceClass anc = new AnotherNamespaceClass();
            Console.WriteLine(anc.internalString);

            //protected 本身的Class或者继承它的Class里可用
            Man man = new Man();
            Console.WriteLine(man.GetPersonName());

            //internal protected
            Class1 class1 = new Class1();
            //Console.WriteLine(class1);
            Class2 class2 = new Class2();
            //Console.WriteLine(class2);
            Console.WriteLine(class2.GetString2());
            Console.WriteLine(class2.GetString2());

            Console.ReadLine();
        }
    }
    class Class2:Class1
    {
        public string GetString2()
        {
            return this.internalProtectdString;
        }
        public void GetString3()
        {
            GetString();
        }
    }
    class Person
    {
        private int age;
        protected string name;
        public int GetAge()
        {
            return age;
        }
        public int Age
        {
            //get { return age;}
            get
            {
                if(CheckAge())
                {
                    return age;
                }
                return -1;

            }
            set { age = value; }
        }
        private bool CheckAge()
        {
            if(age<0)
            {
                return false;
            }
            return true;
        }
    }
    class Man:Person
    {
        public string GetPersonName()
        {
            return this.name;
        }
    }
}
