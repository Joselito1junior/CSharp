using System;
using Generics_1.Entities;

namespace Generics_1
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintService<string> printService = new PrintService<string>();

            Console.Write("How many values?");
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                //int value = int.Parse(Console.ReadLine());
                string value = Console.ReadLine();
                printService.AddValue(value);
            }

            printService.Print();
            Console.WriteLine(printService.First()); 
        }
    }
}
