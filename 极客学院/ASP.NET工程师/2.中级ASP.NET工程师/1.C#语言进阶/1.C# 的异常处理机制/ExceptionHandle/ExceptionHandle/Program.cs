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
