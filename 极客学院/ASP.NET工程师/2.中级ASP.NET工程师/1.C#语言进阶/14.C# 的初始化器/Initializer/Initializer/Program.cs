using System;
using System.Collections.Generic;
using System.Linq;

namespace Initializer
{
    class Program
    {
        static void Main(string[] args)
        {
            ObjectInitializer();
            IntialzerAnonymousType();
            CollectionInitialzer();

            Console.ReadLine();
        }
        private static void ObjectInitializer()
        {
            var student1 = new StudentName("MeiMei", "Wang");
            //先调用无参的构造函数
            var student2 = new StudentName() { FirstName = "MeiMei", LastName = "Wang" };
            var student3 = new StudentName() { ID = 103 };
            var student4 = new StudentName("Lei", "Li") { ID = 104 };

            Console.WriteLine(student1);
            Console.WriteLine(student2);
            Console.WriteLine(student3);
            Console.WriteLine(student4);
        }
        private static void IntialzerAnonymousType()
        {
            var pet = new { Age = 10, Name = "miaomiao" };
            //只读,不能赋值,在Linq里用的非常多
            //pet.Age = 12;
            var students = new List<StudentName>()
            { 
                new StudentName("Li", "li"), 
                new StudentName("Mei", "mei") 
            };
            var froms = new List<StudentFrom>()
            { 
                new StudentFrom(){FirstName="Li",City="Beijing"},
                new StudentFrom(){FirstName="Wang",City="Shanghai"}
            };
            var joinQuery = from s in students
                            join f in froms on s.FirstName equals f.FirstName
                            select new { firstName = s.FirstName, lastName = s.LastName, city = f.City };
            foreach (var item in joinQuery)
            {
                Console.WriteLine("firstName:{0},lastName:{1},city{2}", item.firstName, item.lastName, item.city);
            }
        }
        private static void CollectionInitialzer()
        {
            var students = new List<StudentName>()
            {
                //默认的初始化器
                new StudentName{FirstName="Mei",LastName="Mei",ID = 100},
                new StudentName(){FirstName="Li",LastName="Li",ID = 101},
                new StudentName("Li","Lei"){ID = 102},
                null
            };
            foreach (var item in students)
            {
                if(item != null)
                    Console.WriteLine(item);

            }

            Dictionary<int, StudentName> studentDic =
                new Dictionary<int, StudentName>
            {
                {111,new StudentName{FirstName="Mei",LastName="Mei",ID = 100}},
                {112,new StudentName(){FirstName="Li",LastName="Li",ID = 101}},
            };
            foreach (var item in studentDic)
            {
                Console.WriteLine("key:{0},value:{1}", item.Key, item.Value);
            }
        }
    }
    public class StudentName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int ID { get; set; }

        public StudentName()
        { }
        public StudentName(string _fristName, string _lastName)
        {
            FirstName = _fristName;
            LastName = _lastName;
        }
        public override string ToString()
        {
            return FirstName + " " + ID;
        }
    }
    public class StudentFrom
    {
        public string FirstName { get; set; }
        public string City { get; set; }
    }
}
