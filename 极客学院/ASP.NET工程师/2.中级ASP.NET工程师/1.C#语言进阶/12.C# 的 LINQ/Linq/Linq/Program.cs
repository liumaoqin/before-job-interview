using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            BasicConcept();
            QuerySyntax();
            QueryOperation();
            QueryIntoAndLetKeyword();
            Console.ReadLine();
        }
        private static void BasicConcept()
        {
            // Linq : language Intergarted Query
            // select id,name from employee
            // IEnumerable
            // Linq To SQL, Linq To XML,
            // Linq To DataSet, Linq To Object

            int[] numbers = { 5, 10, 25, 35, 66, 77, 44, 22 };
            // 1. Query Syntax
            var numQuery1 = from num in numbers
                            where num % 2 == 0
                            orderby num
                            select num;
            foreach (var i in numQuery1)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            // 2. Method Syntax
            var numQuery2 = numbers.Where(n => n % 2 == 0).OrderBy(n => n);
            foreach (var i in numQuery2)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }
        private static void QuerySyntax()
        {
            // 1. Data Source
            // IEnumerable
            int[] numbers = { 1, 22, 24, 45, 16, 75, 34 };

            // 2. Query Creation
            //推迟执行;
            var numQuery = from num in numbers
                           where num % 2 == 0
                           orderby num
                           select num;
            //强制执行:Count(),ToList(),ToArray()
            int numCount = numQuery.Count();
            numQuery.ToList();
            numQuery.ToArray();

            // 3. Query execution
            foreach (var num in numQuery)
            {
                Console.Write("{0,3}", num);
            }
            Console.WriteLine();
        }
        private static void QueryOperation()
        {
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8 };
            var querys = from num in numbers
                         where num % 2 == 1 && num % 3 == 1
                         //where num % 2 == 1 || num % 3 == 1
                         orderby num descending //ascending
                         select num;
            foreach (var item in querys)
            {
                Console.Write("{0,2}", item);
            }
            Console.WriteLine();

            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer() { Name = "Jack", City = "Beijing" });
            customers.Add(new Customer() { Name = "LiLei", City = "Beijing" });
            customers.Add(new Customer() { Name = "WangMeiMei", City = "Shanghai" });
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee() { Name = "Jack", ID = 101 });
            employees.Add(new Employee() { Name = "Emily", ID = 102 });

            var customerQuery = from item in customers
                                group item by item.City;

            foreach (var cg in customerQuery)
            {
                Console.WriteLine(cg.Key);
                foreach (var c in cg)
                {
                    Console.WriteLine("  {0}", c.Name);
                }
            }

            var queryJoin = from c in customers
                            join e in employees on c.Name equals e.Name
                            select new { personName = c.Name, personID = e.ID, personCity = c.City };
            foreach (var p in queryJoin)
            {
                Console.WriteLine("{0} {1} {2}",
                    p.personID, p.personName, p.personCity);
            }

        }
        private static void QueryIntoAndLetKeyword()
        {
            List<Customer> customers = new List<Customer>();
            customers.Add(new Customer() { Name = "Jack", City = "Beijing" });
            customers.Add(new Customer() { Name = "LiLei", City = "Beijing" });
            customers.Add(new Customer() { Name = "WangMeiMei", City = "Shanghai" });
            
            // into let keyword
            var customerQuery2 = from item in customers
                                 group item by item.City into cusGroup
                                 where cusGroup.Count() >= 2
                                 select new { City = cusGroup.Key, Number = cusGroup.Count() };
            foreach(var item in customerQuery2)
            {
                Console.WriteLine("{0} Count {1}", item.City, item.Number);
            }
            
            string[] strings = { "hello zilong", "This is Friday!","Are you Happly!"};
            var stringQuery = from s in strings
                              let words = s.Split(' ')
                              from word in words
                              let w = word.ToUpper()
                              select w;
            foreach(var item in stringQuery)
            {
                Console.WriteLine("{0}",item);
            }


        }
    }
    class Customer
    {
        public string Name
        {
            get;
            set;
        }
        public string City
        {
            get;
            set;
        }
    }
    class Employee
    {
        public string Name
        { get; set; }
        public int ID
        { get; set; }
    }
}
