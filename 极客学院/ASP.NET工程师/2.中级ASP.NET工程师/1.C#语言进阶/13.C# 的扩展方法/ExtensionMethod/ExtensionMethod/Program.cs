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
