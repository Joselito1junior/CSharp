using System;
using System.Collections.Generic;
using System.Linq;
using Func_1.Entities;

namespace Func_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();

            list.Add(new Product("Tv", 900.00));
            list.Add(new Product("Mouse", 50.00));
            list.Add(new Product("Tablet", 350.50));
            list.Add(new Product("HD Case", 80.90));

            List<string> result = list.Select(NameUpper).ToList();
            foreach (string s in result)
            {
                Console.WriteLine(s);
            }

            //Outra forma
            Func<Product, string> func = NameUpper;
            List<string> result_1 = list.Select(func).ToList();
            foreach (string s in result_1)
            {
                Console.WriteLine(s);
            }

            //Outra forma (Não foi colocado chaves pois essa função retorna um valor)
            Func<Product, string> func_1 = p => p.Name.ToUpper();
            List<string> result_2 = list.Select(func_1).ToList();
            foreach (string s in result_2)
            {
                Console.WriteLine(s);
            }

            //Outra forma
            List<string> result_3 = list.Select(p => p.Name.ToUpper()).ToList();
            foreach (string s in result_3)
            {
                Console.WriteLine(s);
            }
        }

        static string NameUpper(Product p)
        {
            return p.Name.ToUpper();
        }
    }
}
