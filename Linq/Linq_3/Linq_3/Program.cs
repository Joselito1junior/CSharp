using System;
using System.IO;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using Linq_3.Entities;

namespace Linq_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();
            Console.Write("Digite o path: ");
            string path = Console.ReadLine();

            using(StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(",");
                    string name = line[0];
                    double price = double.Parse(line[1], CultureInfo.InvariantCulture);

                    list.Add(new Product(name, price));
                }
            }

            double r1 = list.Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine("Average price: " + r1.ToString("F2"));

            var names = list.Where(p => p.Price < r1).OrderByDescending(p => p.Name).Select(p => p.Name);
            foreach(string name in names)
                Console.WriteLine(name);
        }
    }
}
