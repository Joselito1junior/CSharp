using System;

namespace ExtensionMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = new DateTime(1988, 04, 27, 3, 30, 00);
            Console.WriteLine(dt.ElapsedTime());

            string s1 = "Good morning dear students";
            Console.WriteLine(s1.Cut(10));
        }
    }
}
