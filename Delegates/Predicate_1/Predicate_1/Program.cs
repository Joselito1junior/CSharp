using System;
using System.Collections.Generic;
using Predicate_1.Entities;

namespace Predicate_1
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

            list.RemoveAll(ProdutTest);
            foreach(Product p in list)
            {
                Console.WriteLine(p);
            }
        }
        public static bool ProdutTest(Product p)
        {
            return p.Price >= 100.00;
        }
    }
}
