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
