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
