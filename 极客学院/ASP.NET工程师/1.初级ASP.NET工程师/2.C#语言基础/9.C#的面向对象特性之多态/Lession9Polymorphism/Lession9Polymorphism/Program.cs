using System;

namespace Lession9Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintHello();
            PrintHello("world");

            Complex c1 = new Complex();
            Complex c2 = new Complex();
            c1.Number = 2;
            c2.Number = 3;
            Complex c3 = c1 + c2;
            Console.WriteLine(c3.Number);

            //动态多态
            //some logic
            //Human h = new Human();
            //h.CleanRoom();
            //if(h is Man)
            //      h.CleanRoomSlowly();
            //else if(h is woman)
            //      h.CleanRoomQuickly();
            //some logic

            //some logic
            //Human h = new Human();
            //h.CleanRoom();
            //some logic

            Human human1 = new Man();
            Human human2 = new Woman();
            human1.ClearnRoom();
            human2.ClearnRoom();

            Console.WriteLine(c2);

            Console.ReadLine();
        }
        public static void PrintHello()
        {
            Console.WriteLine("Hello");
        }
        public static void PrintHello(string toWho)
        {
            Console.WriteLine("Hello {0}", toWho);
        }
        //public static string PrintHello()
        //{
        //    return "Hello";
        //}
    }

    class Complex
    {
        public int Number { get; set; }
        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex c = new Complex();
            c.Number = c1.Number + c2.Number;
            return c;
        }
        public override string ToString()
        {
            return Number.ToString();
        }
    }

    class Human
    {
        public virtual void ClearnRoom()
        {
            Console.WriteLine("Human Clean Room");
        }
    }
    class Man : Human
    {
        public override void ClearnRoom()
        {
            Console.WriteLine("Man Clean Room Slowly");
        }
    }
    class Woman : Human
    {
        public override void ClearnRoom()
        {
            Console.WriteLine("Woman Clean Room Quickly");
        }
    }
}
