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
