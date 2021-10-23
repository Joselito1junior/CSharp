using System;
using System.Globalization;
using System.Collections.Generic;
using Heranca_2.Entities;

namespace Heranca_2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> listProd = new List<Product>();

            Console.Write("Enter the number of products: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Common, used or imported (c/u/i)?: ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Price: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if(ch == 'u')
                {
                    Console.Write("Manufacture date (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    listProd.Add(new UsedProduct(name, price, date));
                }
                else if (ch == 'i')
                {
                    Console.Write("Customs Fee: ");
                    double customFee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    listProd.Add(new ImportedProduct(name, price, customFee));
                }
                else
                {
                    listProd.Add(new Product(name, price));
                }
            }

            Console.WriteLine("PRICE TAGS: ");
            foreach(Product prod in listProd)
                Console.WriteLine(prod.PriceTag());
        }
    }
}
