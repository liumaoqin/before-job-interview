using System;

namespace lession4
{
    class Program
    {
        static void Main(string[] args)
        {
            var person = new Person(5);
            Console.WriteLine(person.GetAge());
            Console.WriteLine(Person.GetFive());
            //person.GetFive();//Error

            Console.WriteLine(person.Age);//默认值为0;
            person.Age = 10;//这是一个属性
            Console.WriteLine(person.GetAge());
            Console.ReadLine();
        }
    }
    class Person:Man,ISuper
    {
        int age;
        public int Age
        {
            get
            {
                return age + 10;
            }
            set
            {
                age = value - 10;
            }
            //private set;
        }
        public Person(int myAge)
        {
            this.age = myAge;
        }
        public int GetAge()// 默认修饰符为private
        {
            return age;
        }
        public static int GetFive()
        {
            return 5;
        }

        public int GetSuper()
        {
            return age + 100;
        }
        public override int GetAbstract()
        {
            return 50;
        }
    }
    abstract class Man
    {
        public string name;
        public string GetName()
        {
            return name;
        }
        public abstract int GetAbstract();
    }
    interface ISuper//只能有方法,索引,属性(property)
    {
        //int name;//接口不能包含字段
        int GetSuper();
    }
}
