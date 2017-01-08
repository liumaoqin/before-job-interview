using System;

namespace lession2
{
    //enum:byte{} enum:short{}
    enum Days { Monday=1, Tuesday, Wenesday, Thursday, FriDay, Saturday, Sunday };
    class Program
    {
        /// <summary>
        /// Main function
        /// </summary>
        /// <param name="args">args</param>
        static void Main(string[] args)
        {
            int intValue = 0;
            System.Int32 intValue2 = 0;
            int intValue3 = new int();

            bool boolValue = true;//System.Boolean
            //sturct,enum;
            //System.ValueType,System.Object

            // /**/

            Person person = new Person();
            person.age = 10;
            Console.WriteLine(person.age);

            Console.WriteLine(Days.Monday);
            var day = Days.Thursday;
            Console.WriteLine(day);
            Console.WriteLine((int)day);
            Console.ReadLine();
        }
        struct Person
        {
            public int age;
            private string name;//该类中可以访问
            internal string fname;//在命名空间内可以访问
            //protected string lastname;//有继承关系的可以访问
        }
        
    }
}
