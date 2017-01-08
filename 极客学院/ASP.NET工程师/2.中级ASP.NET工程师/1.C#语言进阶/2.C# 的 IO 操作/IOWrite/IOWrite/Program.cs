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
