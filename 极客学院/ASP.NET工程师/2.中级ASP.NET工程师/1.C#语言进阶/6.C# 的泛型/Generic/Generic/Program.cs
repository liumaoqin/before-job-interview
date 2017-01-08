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
