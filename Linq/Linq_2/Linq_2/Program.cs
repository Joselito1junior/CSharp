using System;
using System.Collections.Generic;
using System.Linq;
using Linq_2.Entities;

namespace Linq_2
{
    class Program
    {
        static void Print<T>(string message, IEnumerable<T> collection)
        {
            Console.WriteLine(message);
            foreach(T obj in collection)
            {
                Console.WriteLine(obj);
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Category c1 = new Category() { Id = 1, Name = "Tools", Tier = 2 };
            Category c2 = new Category() { Id = 2, Name = "Computers", Tier = 1 };
            Category c3 = new Category() { Id = 3, Name = "Eletronics", Tier = 1 };

            List<Product> products = new List<Product>() {
                new Product() {Id = 1, Name = "Computer", Price = 1100.00, Category = c2},
                new Product() {Id = 2, Name = "Hammer", Price = 90.00, Category = c1}, 
                new Product() {Id = 3, Name = "TV", Price = 1700.00, Category = c3}, 
                new Product() {Id = 4, Name = "Notebook", Price = 1300.00, Category = c2}, 
                new Product() {Id = 5, Name = "Saw", Price = 80.00, Category = c1}, 
                new Product() {Id = 6, Name = "Tablet", Price = 700.00, Category = c2},
                new Product() {Id = 7, Name = "Camera", Price = 700.00, Category = c3},
                new Product() {Id = 8, Name = "Printer", Price = 350.00, Category = c3}, 
                new Product() {Id = 9, Name = "MacBook", Price = 1800.00, Category = c2}, 
                new Product() {Id = 10, Name = "Sound Bar", Price = 700.00, Category = c3}, 
                new Product() {Id = 11, Name = "Level", Price = 70.00, Category = c1} 
            };


            //var r1 = products.Where(p => p.Category.Tier == 1 && p.Price < 900.00);
            var r1 = from p in products where p.Category.Tier == 1 && p.Price < 900 select p;
            Print("TIER 1 AND PRICE < 900: ", r1);

            // var r2 = products.Where(p => p.Category.Name == "Tools").Select(p => p.Name);
            var r2 = from p in products where p.Category.Name == "Tools" select p.Name;
            Print("PRRODUCTS FROM TOOLS: ", r2);

            //var r3 = products.Where(p => p.Name[0] == 'C').Select(p => p.Name + ", " + p.Price + ", " + p.Category.Name);
            //Ou
            //var r3 = products.Where(p => p.Name[0] == 'C').Select(p => new { p.Name, p.Price, CategoryName = p.Category.Name });
            var r3 = from p in products where p.Name[0] == 'C' select new { p.Name, p.Price, CategoryName = p.Category.Name };
            Print("PRRODUCTS FROM TOOLS THAT BEGIN WITH C: ", r3);

            //var r4 = products.Where(p => p.Category.Tier == 1).OrderBy(p => p.Price).ThenBy(p => p.Name);
            var r4 = from p in products where p.Category.Tier == 1 orderby p.Name orderby p.Price select p;
            Print("TIER 1 ORDER BY PRICE THEN BY NAME: ", r4);

            //var r5 = r4.Skip(2).Take(4);
            var r5 = (from p in r4 select p).Skip(2).Take(4);
            Print("TIER 1 ORDER BY PRICE THEN BY NAME SKUP 2 TAKE 4", r5);

            //var r6 = products.FirstOrDefault();
            var r6 = (from p in products select p).FirstOrDefault();
            Console.WriteLine("FIRST TEST1 or DEFAULT: " + r6);

            //var r7 = products.Where(p => p.Price > 3000).FirstOrDefault();
            var r7 = (from p in products where p.Price > 3000 select p).FirstOrDefault();
            Console.WriteLine("FIRST TEST2 or DEFAULT: " + r7);

            var r8 = products.Where(p => p.Id == 3).SingleOrDefault();
            Console.WriteLine("SINGLE OR DEFAULT 1: " + r8);

            var r9 = products.Max(p => p.Price);
            Console.WriteLine("MAX PRICE 1: " + r9);

            var r10 = products.Min(p => p.Price);
            Console.WriteLine("MAX PRICE 1: " + r10);

            var r11 = products.Where(p => p.Category.Id == 1).Sum(p => p.Price);
            Console.WriteLine("CATEGORY 1 SUM PRICES: " + r11);

            var r12 = products.Where(p => p.Category.Id == 1).Average(p => p.Price);
            Console.WriteLine("CATEGORY 1 AVERAGE: " + r12);

            var r13 = products.Where(p => p.Category.Id == 5).Select(p => p.Price).DefaultIfEmpty(0.0).Average();
            Console.WriteLine("CATEGORY 5 AVERAGE PRICES: " + r13);

            var r14 = products.Where(p => p.Category.Id == 1).Select(p => p.Price).Aggregate((x, y) => x + y);
            Console.WriteLine("CATEGORY 1 AGGREGATE SUM: " + r14);

            var r15 = products.Where(p => p.Category.Id == 5).Select(p => p.Price).Aggregate(0.0, (x, y) => x + y);
            Console.WriteLine("CATEGORY 5 AGGREGATE SUM: " + r15);

            //var r16 = products.GroupBy(p => p.Category);
            var r16 = from p in products group p by p.Category;
            foreach(IGrouping<Category, Product> group in r16)
            {
                Console.WriteLine("Category " + group.Key.Name + ": ");
                foreach(Product p in group)
                {
                    Console.WriteLine(p);
                }
                Console.WriteLine();
            }

        }
    }
}