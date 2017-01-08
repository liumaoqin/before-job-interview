using System;

namespace lession9Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Dog dog = new Dog();
            dog.Age = 10;
            dog.Bite();
            dog.GetAge();
            dog.BiteMan();

            Console.WriteLine("----------------------");
            Dog oldDog = new Dog(17);

            Console.WriteLine("----------------------");
            Animal dog2 = new Dog();
            dog2.Bite();
            dog2.BiteMan2();
            ((Dog)dog2).BiteMan2();

            Console.ReadLine();
        }
    }
    class Animal
    {
        public int Age { get; set; }

        public Animal()
        {
            Console.WriteLine("Animal constructor");
        }
        public Animal(int age)
        {
            Console.WriteLine("Old Animal constructor");
            this.Age = age;
        }
        public virtual void Bite()
        {
            Console.WriteLine("Animal bite");
        }
        public virtual void GetAge()
        {
            Console.WriteLine(this.Age);
        }
        public virtual void BiteMan()
        {
            Console.WriteLine("Animal bite man");
        }
        public void BiteMan2()
        {
            Console.WriteLine("Animal bite man2");
        }
    }
    //sealed class Dog : Animal //sealed 关键字表示该类无法被继承
    class Dog : Animal
    {
        public Dog()
        {
            Console.WriteLine("Dog constructor");
        }
        //public Dog(int age):base(age)
        public Dog(int age)
            : this()
        {
            Console.WriteLine("Old Dog constructor");
            this.Age = age;
        }
        public override void Bite()
        {
            //base.Bite();
            Console.WriteLine("Dog bite");
        }
        public override void BiteMan()
        {
            Console.WriteLine("Dog bite man");
        }
        public new void BiteMan2()
        {
            Console.WriteLine("Dog bite man2");
        }
    }
    class JinMao : Dog
    {

    }
}
