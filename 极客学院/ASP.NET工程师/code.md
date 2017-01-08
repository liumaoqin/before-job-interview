## 1.初级ASP.NET工程师
### 2.C#语言基础
#### 2.C#的值类型

```
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
        static void Main(string[] args)s
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

```
#### 3.C#的引用类型-part1
```
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
```

#### 3.C#的引用类型-part2
```
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
```

#### 4.C#的类型转换
```
using System;

namespace Lession5TypeConvertion
{
    class Program
    {
        static void Main(string[] args)
        {
            //隐式转换
            int i = 10;
            long l = i;
            C1 c1 = new C2();

            //显示转换
            double d = 10.05;
            int iFromD = (int)d;
            Console.WriteLine(iFromD);
            C1 c11 = new C1();
            //C2 c2 = (C2)c11;
            try
            {
                C2 c2 = (C2)c11;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine(c11 is C1);//true
            Console.WriteLine(c11 is C2);//false

            C2 c22 = c11 as C2;//编译成功,运行成功,无法转换时,返回null.
            Console.WriteLine(c22 == null);//true,降低消耗,只能用于非null类型或引用类型,比如值类型,就不是非null类型

            //int iAs = "s" as int;
            //错误	1	as 运算符必须用于引用类型或可以为 null 的类型(“int”是不可以为 null 值的类型)	E:\极客学院2\ASP.NET工程师\1.初级ASP.NET工程师\2.C#语言基础\4.C#的类型转换\Lession5TypeConvertion\Lession5TypeConvertion\Program.cs	38	23	Lession5TypeConvertion

            Console.WriteLine("------------------------");
            string sFrom1 = i.ToString();
            int iFroms = Convert.ToInt32("10");
            //int iFroms2 = Convert.ToInt32("zilong");//System.FormatException

            int iFrom3 = Int32.Parse("101");
            //int iFrom4 = Int32.Parse("zilong");//System.FormatException

            int iFrom5;
            bool succeed = Int32.TryParse("zilong", out iFrom5);
            Console.WriteLine(iFrom5);//0
            //IConvertible,TypeConverter

            Console.WriteLine("------------------------");
            int iToBoxing = 100;
            object iBoxed = iToBoxing;

            int iUnBoxing = (int)iBoxed;
            object nullOjbect = iFrom5;
            int iNUll = (int)nullOjbect;

            int? iNUllable = null; // = null;
            System.Nullable<int> iNUllable2 = 100;//和上一句等价
            //Console.WriteLine(iNUllable.Value);
            Console.WriteLine(iNUllable.HasValue);
            Console.WriteLine(iNUllable.GetValueOrDefault());
            Console.WriteLine(iNUllable2.GetValueOrDefault());

            int iii = iNUllable ?? 999;
            int iiii = iNUllable2 ?? 999;
            Console.WriteLine(iii);
            Console.WriteLine(iiii);

            Console.ReadLine();
        }
    }
    class C1
    { }
    class C2 : C1
    { }
}
```

#### 5.C#的逻辑语句
```
using System;
using System.Collections.Generic;

namespace Lession5Statement
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Condition
            bool condition = true;
            //if(true)
            //if (condition)
            int ten = 10;
            //if (ten >10)
            //if (!false && true)
            //if (!false || true)//if(!false & false)
            object nullObject = null;
            //if (!false || (bool)nullObject)
            if (ten > 100)
            {
                Console.WriteLine("True Condition");
                if (true)
                {
                    Console.WriteLine("true and true");
                }
            }
            else if (ten > 5)
            {
                Console.WriteLine("ten > 5 and tem <= 100");
            }
            else
            {
                Console.WriteLine("Else is Here");
            }

            ten = 100;
            int ifelse = ten < 100 ? ten : 99;
            Console.WriteLine(ifelse);

            int switchKey = 100;
            switch(switchKey)
            {
                case 10:
                    Console.WriteLine("switchKey is 10");
                    break;
                case 100:
                    Console.WriteLine("switchKey is 10");
                    break;
                default:
                    Console.WriteLine("I don't know switch key");
                    break;

            }
            #endregion

            #region Loop
            for (int i = 0; i < 5;i++ )
            {
                Console.WriteLine(i);
                if(i==3)
                {
                    break;//continute
                }
            }
            int iValue;
            int jValue = 10;
            for(iValue=0,Console.WriteLine("Start:{0}",iValue);iValue<jValue;iValue++,jValue--,Console.WriteLine("i={0},j={1}",iValue,jValue))
            {
                Console.WriteLine("Body of the loop");
            }
            //无限循环
            //for (; ; )
            //{ }

            bool stop = false;
            for (; !stop; )
            {
                stop = true;
                Console.WriteLine("Can u stop");
            }

            List<int> listInt = new List<int>() { 1, 2, 3, 4 };
            foreach (var intInList in listInt)//实现了IEnumerable接口
            {
                Console.WriteLine(intInList);
            }

            int n = 1;
            //n++ n=n+1
            //++n
            while(n++ < 6)
            {
                Console.WriteLine("n is {0}", n);
            }
            do
            {
                Console.WriteLine("time");
            }
            while (false);
            #endregion

            Console.ReadLine();
        }
    }
}
```

#### 6.C#的集合类型
```
using System;
using System.Collections;
using System.Collections.Generic;

namespace Lession6Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Array
            //值类型,应用类型
            //System.Array
            int[] numbers = new int[5];
            string[,] names = new string[5, 4];//二位数组
            byte[][] scores = new byte[5][];

            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = new byte[i + 3];
            }

            for (int i = 0; i < scores.Length; i++)
            {
                Console.WriteLine("Length of row {0} is {1}", i, scores[i].Length);
            }

            int[] numbers2 = new int[5] { 1, 2, 3, 4, 5 };
            int[] numbers3 = new int[] { 1, 2, 3, 4, 5 };
            int[] numbers4 = { 1, 2, 3, 4, 5 };

            string[,] names2 = { { "g", "k" }, { "h", "j" } };
            int[][] numbers5 = { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6, 7 } };

            Console.WriteLine(numbers2[2]);
            Console.WriteLine(numbers2.Length);
            //IEnumerable,IEnumerator
            foreach (int i in numbers2)
            {
                Console.WriteLine(i);
            }
            #endregion

            #region ArrayList,List
            Console.WriteLine("------------------------");
            ArrayList al = new ArrayList(); //object
            al.Add("zilong");
            al.Add(5);
            al.Add(100);
            al.Remove(5);

            foreach(var e in al)
            {
                Console.WriteLine(e);
            }
            Console.WriteLine(al[0]);

            List<int> intList = new List<int>();
            intList.Add(500);
            intList.AddRange(new int[] { 501, 502 });
            Console.WriteLine(intList.Contains(2000));
            Console.WriteLine(intList.IndexOf(2000));
            intList.Remove(500);
            intList.Insert(2, 999);
            #endregion

            #region Hashtable,Dictionay,SortList,Stack,Queue
            Console.WriteLine("------------------------");
            Hashtable ht = new Hashtable();//object,object
            ht.Add("first", "zi");
            ht.Add("second", "long");
            ht.Add(100, 100);
            Console.WriteLine(ht["second"]);
            Console.WriteLine(ht[100]);
            Console.WriteLine(ht[99]);//return null;


            Dictionary<string, string> d = new Dictionary<string, string>();//指定类型
            d.Add("first", "zilong");
            //d.Add(100,100)
            //Console.WriteLine(d["99"]);//抛出异常
            //Dictionary在多线程里,不是线程安全
            //应该使用 ConcurrentDictionary

            SortedList<int, int> sl = new SortedList<int, int>();//根据key排序
            sl.Add(5,105);
            sl.Add(2,102);
            sl.Add(9, 95);
            foreach(var sle in sl)
            {
                Console.WriteLine(sle.Value);
            }

            //stack queue
            Stack stack = new Stack();
            stack.Push(1); stack.Push(2); stack.Push(3); stack.Push(4); stack.Push(5);
            while(stack.Count >0)
            {
                Console.WriteLine(stack.Pop());
            }
            Queue queue = new Queue(5);
            queue.Enqueue(1); queue.Enqueue(2); queue.Enqueue(3); queue.Enqueue(4); queue.Enqueue(5);
            while(queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
            #endregion
            Console.ReadLine();
        }
    }
}
```

#### 7.C# 的面向对象特性之封装
*AnotherAssembly*
```
using System;

namespace AnotherAssembly
{
    public class Class1
    {
        internal protected string internalProtectdString = "zilong";
        internal protected string GetString()
        {
            return internalProtectdString;
        }
    }
}
```
*Lession7Encapsulation.AnotherNamespaceClass*
```
namespace Lession7EncapsulationAnother
{
    class AnotherNamespaceClass
    {
        internal string internalString = "zilong";
    }
}
```
*Lession7Encapsulation.Program*
```
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
```

#### 8.C# 的面向对象特性之继承
```
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
```
#### 9.C#的面向对象特性之多态
```
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
```
## 2.中级ASP.NET工程师
### 1.C#语言进阶
#### 1.C# 的异常处理机制
```
using System;
using System.IO;

namespace ExceptionHandle
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            try
            {
                int y = 100 / x;
            }
            catch(NullReferenceException e) // System.Exception
            {
                Console.WriteLine(e.Message);
                throw;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine(e.Message);
            }
            //catch(Exception e) //第一开销太大,第二不能更细致处理异常
            //{
            //    Console.WriteLine(e.Message);
            //}
            finally
            {
                Console.WriteLine("Anyway,we arrive here!");
            }
            Console.WriteLine("After try catch");

            //throw new NullReferenceException();

            #region 常见异常
            var ae = new ArgumentException();
            var ane = new ArgumentNullException();
            var aore = new ArgumentOutOfRangeException();
            var dne = new DirectoryNotFoundException();
            var foe = new FileNotFoundException();
            var ioe = new InvalidCastException();
            var nie = new NotImplementedException();
            #endregion

            if(true)
            {
                //logic
            }
            try //异常的处理开销很大
            {
                throw new Exception();
            }
            catch(Exception e)
            {
                //logic
            }

            Console.ReadKey();
        }
    }
}
```
#### 2.C# 的 IO 操作
*IO*
```
using System;
using System.IO;

namespace IO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(File.Exists(@"C:\HelloIO\IO.txt"));
            Console.WriteLine(Directory.Exists(@"C:\HelloIO\"));

            string path = ".";
            if(args.Length > 0)
            {
                if(Directory.Exists(args[0]))
                {
                    path = args[0];
                }
                else
                {
                    Console.WriteLine("{0} not found; using current dirctory;", args[0]);
                }
            }
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach(FileInfo f in dir.GetFiles("*.exe"))
            {
                string name = f.Name;
                long size = f.Length;
                DateTime createionTime = f.CreationTime;
                Console.WriteLine("{0,-12:N0} {1,-20:g} {2}", size, createionTime, name);
            }

            Console.ReadKey();
        }
    }
}
```
*IORead*
```
using System;
using System.IO;

namespace IORead
{
    class Program
    {
        private const string FILE_NAME = "Test.txt";
        static void Main(string[] args)
        {
            if (!File.Exists(FILE_NAME))
            {
                Console.WriteLine("{0} does not exist!", FILE_NAME);
                Console.ReadLine();
                return;
            }
            using(StreamReader sr = File.OpenText(FILE_NAME))
            {
                string input;
                while((input = sr.ReadLine()) != null)
                {
                    Console.WriteLine(input);
                }
                Console.WriteLine("The end of the stream");
                sr.Close();
            }

            //FileStream fs = new FileStream(FILE_NAME, FileMode.Open, FileAccess.Read);
            //BinaryReader r = new BinaryReader(fs);
            //for (int i = 0; i < 11; i++)
            //{
            //    Console.WriteLine(r.ReadString());
            //}

            //r.Close();
            //fs.Close();

            Console.ReadLine();
        }
    }
}
```
*IOWrite*
```
using System;
using System.IO;

namespace IOWrite
{
    class Program
    {
        private const string FILE_NAME = "Test.txt";
        static void Main(string[] args)
        {
            //if(File.Exists(FILE_NAME))
            //{
            //    Console.WriteLine("{0} aleady existes!", FILE_NAME);
            //    Console.ReadLine();
            //    return;
            //}
            //FileStream fs = new FileStream(FILE_NAME,FileMode.Create);
            //BinaryWriter w = new BinaryWriter(fs);

            //for(int i=0;i<11;i++)
            //{
            //    w.Write("a");
            //}

            //w.Close();
            //fs.Close();

            using(StreamWriter w = File.AppendText("test.txt"))
            {
                Log("hehe", w);
                Log("Hello jikexueyuan", w);

                w.Close();
            }
        }

        public static void Log(string logMessage,TextWriter w)
        {
            w.Write("\r\nLog Entry:");
            w.Write(" ：{0}", logMessage);

            w.Flush();
        }
    }
}
```
#### 3.C# 的索引器
```
using System;

namespace Indexer
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = new IndexedNames();
            names[0] = "hello";
            names[1] = "zilong";
            names[2] = "we";
            names[3] = "are";
            names[4] = "leaning";
            names[5] = "C#";
            names[6] = "Indexer";
            names[7] = "-";
            names[8] = "Indexex";
            names[9] = "syntax";

            for(int i =0; i<10;i++)
            {
                Console.WriteLine(names[i]);
            }
            Console.WriteLine(names["C#"]);
            Console.WriteLine(names["syntax"]);
            Console.WriteLine(names["2016"]);
            Console.ReadLine();
        }
    }
    class IndexedNames
    {
        private string[] nameList = new string[10];
        public IndexedNames()
        {
            for(int i=0;i<nameList.Length;i++)
            {
                nameList[i] = "N/A";
            }
        }
        public string this[int index]
        {
            get
            {
                string tmp;
                if(index >=0 && index <= nameList.Length-1)
                {
                    tmp = nameList[index];
                }
                else
                {
                    tmp = "";
                }
                return tmp;
            }
            set
            {
                if (index >= 0 && index <= nameList.Length - 1)
                {
                    nameList[index] = value;
                }
            }
        }
        public int this[string name]
        {
            get
            {
                int index = 0;
                while (index < nameList.Length)
                {
                    if (nameList[index] == name)
                    {
                        return index;
                    }
                    index++;
                }
                return -1;
            }
        }
    }
    class Employee //不合理的演示,不符合语法的语义
    {
        public double this[int year]
        {
            get
            {
                //return salary;
                return 0;
            }
        }
    }

    public interface ISomeInterface
    {
        int this[int index]
        {
            get;
            set;
        }
    }
}
```
#### 4.C# 的委托
*Delegate*
```
using System;

namespace Delegate
{
    delegate int NumberChanger(int p);
    class Program
    {
        static int num = 10;
        static void Main(string[] args)
        {
            //System.Delegate delegate
            NumberChanger change = new NumberChanger(AddNum);
            change(20);
            Console.WriteLine("value of num: {0}", num);

            //实例方法的委托
            Console.WriteLine("------------------------------");
            MyClass mc = new MyClass();
            NumberChanger change2 = new NumberChanger(mc.AddNum);
            change2(120);
            Console.WriteLine("value of instance num:{0}", mc.num);

            NumberChanger change3 = new NumberChanger(mc.MultiNum);
            change3(2);
            Console.WriteLine("value of instance num:{0}", mc.num);

            Console.ReadLine();
        }
        public static int AddNum(int p)
        {
            num += p;
            return num;
        }
    }
    class MyClass
    {
        public int num = 10;

        public int AddNum(int p)
        {
            num += p;
            return num;
        }
        public int MultiNum(int p)
        {
            num *= p;
            return num;
        }
    }
}
```
*MultiCasingDelegate*
```
using System;

namespace MultiCasingDelegate
{
    delegate void D(int i);
    class Program
    {
        static void Main(string[] args)
        {
            D cd1 = new D(C.M1);
            cd1(-1);
            Console.WriteLine();
            D cd2 = new D(C.M2);
            cd2(-2);
            Console.WriteLine();

            //委托有一个按顺序的调用列表(类似Stack)
            D cd3 = cd1 + cd2;
            cd3(-3);
            Console.WriteLine();

            C c = new C();
            D cd4 = new D(c.M3);
            cd3 += cd4;
            cd3(-9);
            Console.WriteLine();

            cd3 += cd1;
            cd3(-9);
            Console.WriteLine();
            cd3 -= cd1;
            cd3(-9);
            Console.WriteLine();

            cd3 -= cd4;
            cd3 -= cd2;
            cd3 -= cd2;
            //cd3 -= cd1;
            if(cd3 != null)//避免空引用异常
            {
                cd3(77);
            }
            cd3 -= cd1;
            //即使空了之后一样可以编译和运行,但该操作是无效的
            cd3 -= cd1;

            Console.ReadLine();
        }
    }
    class C
    {
        public static void M1(int p)
        {
            Console.WriteLine("M1 : {0}", p);
        }
        public static void M2(int p)
        {
            Console.WriteLine("M2 : {0}", p);
        }
        public void M3(int p)
        {
            Console.WriteLine("M3 : {0}", p);
        }
    }
}
```
#### 5.C# 的事件
*Event*
```
using System;

namespace Event
{
    public delegate void EventHandler2(object sender,EventArgs e);
    class Program
    {
        static void Main(string[] args)
        {
            var e = new EventTest(5);
            e.SetValue(10);
            e.ChangeNum +=
                new EventTest.NumMainipulationHandler(EventTest.EventFired);
            e.SetValue(100);

            Console.WriteLine("------------------------");
            I i = new MyClass();
            i.MyEvent += new MyDelegate(f);
            i.FireAway();

            Console.ReadLine();
        }
        public static void f()
        {
            Console.WriteLine("This is called when the event fired");
        }
    }
    class EventTest
    {
        private int value;
        public delegate void NumMainipulationHandler();
        //那一种的Delegate可以绑定到Event上
        public event NumMainipulationHandler ChangeNum;
        //规定Delegate的范围(Delegate也可以实现Event的所有功能)
        //但是Delegate限制的是Method,Event限制的是Delegate
        //Button.Click为EventHanlder类型的Event
        public EventTest(int n)
        {
            SetValue(n);
        }
        public static void EventFired()
        {
            Console.WriteLine("Binded event fired");
        }
        public virtual void OnNumChanged()
        {
            if (ChangeNum != null)
            {
                ChangeNum();
            }
            else
            {
                Console.WriteLine("Event Fired");
            }
        }
        public void SetValue(int n)
        {
            if (value != n)
            {
                value = n;
                OnNumChanged();
            }
        }
    }

    public delegate void MyDelegate();
    public interface I
    {
        event MyDelegate MyEvent;
        event EventHandler MyGuidlineEvent;//sender,EventArgs
        void FireAway();
    }
    public class MyClass : I
    {
        public event MyDelegate MyEvent;
        public void FireAway()
        {
            if(MyEvent != null)
            {
                MyEvent();
            }
        }
    }
}
```
*WinFormEvent*
```
using System;
using System.Windows.Forms;

namespace WinFormEvent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello Button");
        }
    }
}
```
#### 6.C# 的泛型
*Generic*
```
using System;

namespace Generic
{
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            //泛型在Class上的实现
            MyGenericArray<int, string> intArray = new MyGenericArray<int, string>(5);
            for (int index = 0; index < 5; index++)
            {
                intArray.SetItem(index, index * 5);
            }
            for (int index = 0; index < 5; index++)
            {
                Console.Write(intArray.GetItem(index) + " ");
            }
            Console.WriteLine();

            MyGenericArray<char, string> charArray = new MyGenericArray<char, string>(5);
            for (int index = 0; index < 5; index++)
            {
                charArray.SetItem(index, (char)(index + 97));
            }
            for (int index = 0; index < 5; index++)
            {
                Console.Write(charArray.GetItem(index) + " ");
            }
            Console.WriteLine();

            Console.WriteLine("------------------------");//泛型在方法上的实现
            ParentGeneric<int,string> gm = new ParentGeneric<int,string>();
            gm.GenericMethod<string>("Hello Generic Method");
            gm.GenericMethod<int>(100);

            string s1 = "hello";
            string s2 = "zilong";
            Swap<string>(ref s1,ref s2);
            Console.WriteLine("item1 = {0}, item2 = {1}", s1, s2);

            int i1 = 100;
            int i2 = 99;
            Swap<int>(ref i1, ref i2);
            Console.WriteLine("item1 = {0}, item2 = {1}", i1, i2);

            Console.ReadLine();
        }
        public static void Swap<T>(ref T item1,ref T item2)
        {
            T temp = item1;
            item1 = item2;
            item2 = temp;
        }
    }
    //1.提高数据的重用性
    //2.类型安全的,在实例化的时候规定的它的数据类型
    //3.这样写性能也是比较好的,因为用泛型的话不用编译那么多代码
    public class MyGenericArray<T, K>
        //public class MyGenericArray<T,K> //例如Dictionary
        where T : struct
        where K : class
    //认真查查泛型where的几个类型,struct为值类型,如果用了string,则不能通过编译
    //strut,class,interface,instance class(Employee,Employee的继承类),Attribute
    {
        private T[] array;
        public MyGenericArray(int size)
        {
            array = new T[size + 1];
        }
        public T GetItem(int index)
        {
            return array[index];
        }
        public void SetItem(int index, T item)
        {
            array[index] = item;
        }
    }
    public class ParentGeneric<T, K>
        where T : struct
        where K : class
    {
        //实现一个泛型的方法
        public void GenericMethod<X>(X x)
        {
            Console.WriteLine(x.ToString());
        }
    }
    public class SubClass : ParentGeneric<int, string>
    { }
    public class SubGeneriClass<T, K> : ParentGeneric<T, K>
        where T : struct
        where K : class
    { }

}
```
*GenericInDelegate*
```
using System;

namespace GenericInDelegate
{
    delegate T NumberChange<T>(T n);//Event,interface
    class Program
    {
        static int num = 0;
        public static int AddNum(int p)
        {
            num += p;
            return num;
        }
        public static int MultiNum(int p)
        {
            num *= p;
            return num;
        }
        static void Main(string[] args)
        {
            NumberChange<int> nc1 = new NumberChange<int>(AddNum);
            NumberChange<int> nc2 = new NumberChange<int>(MultiNum);
            nc1(25);
            Console.WriteLine(num);
            nc2(5);
            Console.WriteLine(num);

            Console.ReadLine();
        }
    }
}
```
#### 7.C# 的 Attribute
*Attribute*
```
#define DEBUG
using System;
using System.Diagnostics;

namespace Attribute
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass.Message("In Main Function");
            Function1();
            Console.ReadLine();
        }
        //警告	1	“Attribute.Program.Function1()”已过时:“Don't user old Method”
        [Obsolete("Don't user old Method")]
        static void Function1()
        {
            MyClass.Message("In Function1");
            Function2();
        }
        static void Function2()
        {
            MyClass.Message("In Function2");
        }
    }
    public class MyClass
    {
        [Conditional("DEBUG")]
        public static void Message(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
```
*CreateAttribute*
```
using System;

namespace CreateAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            HelpAttribute helpAttribute;
            foreach(var attr in typeof(AnyClass).GetCustomAttributes(true))
            {
                helpAttribute = attr as HelpAttribute;
                if(helpAttribute != null)
                {
                    Console.WriteLine("AnyClass Description:{0}",
                        helpAttribute.Description);
                }
            }
            Console.ReadLine();
        }
    }
    //AttributeUsage这个Attribute的使用范围
    [AttributeUsage(AttributeTargets.Class,AllowMultiple=false,Inherited=false)]
    //AllowMultiple 是否可以放置多个
    //Inherited 继承的类是否继承该Attribute
    public class HelpAttribute:Attribute
    {
        protected string description;
        public HelpAttribute(string _description)
        {
            this.description = _description;
        }
        public string Description
        {
            get
            {
                return this.description;
            }
        }
        public string Name
        {
            get;
            set;
        }
    }
    //value type, System.Type, object, enum,
    [Help("this is a do-nothing class",Name="zilong")]
    public class AnyClass
    { }
}
```
#### 8.C# 的反射机制
*Reflection*
```
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
```
*ReflectionInAssembly*
```
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
```
#### 9.C# 的预处理指令
```
#define DEBUG
//#undef DEBUG
// /define:DEBUG
#define TRACE
using System;

namespace PreProcessor
{
    #pragma warning disable 414,3021 //Disable #warning
    [CLSCompliant(false)]
    class Program
    {
        static void Main(string[] args)
        {
            #region hello zilong
            //logic
            //logic
            #endregion

            #if(DEBUG)
            Console.WriteLine("Debugging is enabled");
            #elif(TRACE)
            Console.WriteLine("Tracing is enabled");
            #else
            Console.WriteLine("Debugging is not enabled");
            #endif

            Console.WriteLine("------------------------");
            #if DEBUG
            #line 200 " Special" //设置当前行数为200行
            #warning DEBUG is defined
            //#error I'm Error
            #endif

            #line default //还原文件的行数
            #warning I'm not happy

            Console.WriteLine("------------------------");
            //文件的checksum
            #pragma checksum "filename" "{guid}" "check bytes"

            Console.ReadLine();
        }
    }
    #pragma warning restore 3021 //还原#warning
    [CLSCompliant(false)]
    //警告	1	由于程序集没有 CLSCompliant 特性，因此“PreProcessor.D”不需要 CLSCompliant 特性
    class D
    {
        int i = 1;
        public void M()
        {

        }
    }
}
```
#### 10.C# 的正则表达式
```
using System;
using System.Collections.Generic;

namespace Regex
{
    using System.Text.RegularExpressions;
    class Program
    {
        static void Main(string[] args)
        {
            var s1 = "abc";
            var pattern = "abc";
            Console.WriteLine(Regex.IsMatch(s1, pattern));

            RegexIsMatch();
            RegexMatch();
            RegexReplace();
            RegexSplit();
            Matches();
            Groups();

            Console.ReadLine();
        }
        private static void RegexIsMatch()
        {
            //Regex r = new Regex();
            string[] values = { "111-22-3333", "111-2-3333" };
            string pattern2 = @"^\d{3}-\d{2}-\d{4}$";
            foreach (var item in values)
            {
                if (Regex.IsMatch(item, pattern2))
                {
                    Console.WriteLine("{0} is valid", item);
                }
                else
                {
                    Console.WriteLine("{0} is note valid", item);
                }
            }
        }
        private static void RegexMatch()
        {
            var input = "This is apple apple computer and iPad !";
            var pattern = @"\b(\w+)\W+(\1)\b";
            Match match = Regex.Match(input, pattern);
            while(match.Success)
            {
                Console.WriteLine("Duplication {0} found",match.Groups[1].Value);
                match = match.NextMatch();
            }
        }
        private static void RegexReplace()
        {
            string pattern = @"\b\d+\.\d{2}\b";
            string replacement = "$$$&";

            string input = "Total cost : 103.64";
            Console.WriteLine(Regex.Replace(input, pattern, replacement));
        }
        private static void RegexSplit()
        {
            string input = "1. Egg 2. Bread 3. Mike 4. Coffee";
            string pattern = @"\b\d{1,2}\.\s";
            foreach(string item in Regex.Split(input,pattern))
            {
                if(!string.IsNullOrEmpty(item))
                {
                    Console.WriteLine(item);
                }
            }
        }
        private static void Matches()
        {
            MatchCollection matches;
            List<string> results = new List<string>();
            List<int> matchPosition = new List<int>();

            Regex r = new Regex("abc");
            matches = r.Matches("123abc4abcd");
            foreach(Match match in matches)
            {
                Console.WriteLine("{0} found at position {1}",
                    match.Value, match.Index);
                Console.WriteLine("{0}", match.Result("$&, hello zilong!"));
                //$&表示匹配的结果
            }
        }
        private static void Groups()
        {
            string input = "Born: July 28, 1989";
            string pattern = @"\b(\w+)\s(\d{1,2}),\s(\d{4})\b";

            Match match = Regex.Match(input, pattern);
            if(match.Success)
            {
                for(int ctr=0;ctr<match.Groups.Count;ctr++)
                {
                    Console.WriteLine("Group {0}:{1}", ctr, match.Groups[ctr].Value);
                }
            }
        }
    }
}
```
####　11.C# 的匿名函数
```
using System;

namespace Anonymous
{

    class Program
    {
        delegate void TestDelegate(string s);
        delegate int del(int i);
        delegate TResult Func<TArg0, TResult>(TArg0 arg0);
        static void M(string s)
        {
            Console.WriteLine(s);
        }
        static void Main(string[] args)
        {
            DelegateHistory();
            StartThread();
            lambda();

            Console.ReadLine();
        }
        private static void DelegateHistory()
        {
            TestDelegate testDelA = new TestDelegate(M);

            // C# 2.0 Anonymous Method
            TestDelegate testDelB = delegate(string s) { Console.WriteLine(s); };

            // C# 3.0 lambda Expression
            TestDelegate testDelC = (x) => { Console.WriteLine(x); };

            testDelA("Hello. this is a delegate");
            testDelB("This is a anonymous method");
            testDelC("This is a lamba expression");
        }
        private static void StartThread()
        {
            System.Threading.Thread t1 = new System.Threading.Thread(
                delegate()//not allow "ref out" keyword and unsafe code
                {
                    System.Console.Write("hello, ");
                    System.Console.WriteLine("world!");
                }
            );
            t1.Start();
        }
        public static void lambda()
        {
            // () => Expression
            del myDelegate = x => x * x;//只有一个参数的是否可以不写括号
            del myDelegate2 = (x) => { x = x + 2; return  x * x; };

            Func<int, bool> myFunc = x => x == 5;
            Console.WriteLine(myFunc(10));
        }
    }
}
```
#### 12.C# 的 LINQ
```
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
```
#### 13.C# 的扩展方法
```
using System;
using System.Linq;

namespace ExtensionMethod
{
    public enum Grades { F = 0, E = 1, D = 2, B = 3, A = 4 };
    class Program
    {
        static void Main(string[] args)
        {
            DeomLinq();
            StringCount();

            var g1 = Grades.A;
            var g2 = Grades.D;
            var g3 = Grades.F;
            Console.WriteLine(g1.IsPass());
            Console.WriteLine(g2.IsPass());
            Console.WriteLine(g3.IsPass());

            Extension.minPass = Grades.B;
            Console.WriteLine(g1.IsPass());
            Console.WriteLine(g2.IsPass());
            Console.WriteLine(g3.IsPass());

            Console.ReadLine();
        }
        private static void DeomLinq()
        {
            int[] ints = { 12, 45, 13, 45, 63, 14, 46, 47 };
            var result = ints.OrderBy(n => n);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
        private static void StringCount()
        {
            string s = "this is zilong C# tutorial!";
            Console.WriteLine("Word Count is {0}.", s.WordCunt());
        }
    }
    //扩展方法写在静态类上
    public static class StringExtension
    {
        public static int WordCunt(this string str)
        {
            return str.Split(new char[] { ' ', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries).Length;
        }
    }
    public static class Extension
    {
        public static Grades minPass = Grades.D;
        public static bool IsPass(this Grades grade)
        {
            return grade >= minPass;
        }
    }
}
```
#### 14.C# 的初始化器
```
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
```
