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
