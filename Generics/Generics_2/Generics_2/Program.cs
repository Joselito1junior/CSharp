using System;
using System.Globalization;
using Generics_2.Entities;
using Generics_2.Services;

namespace Generics_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            Product prod;
            CalculationService calculation = new CalculationService();

            Console.Write("Enter N: ");
            int n = int.Parse(Console.ReadLine());

            for(int i = 0; i < n; i++)
            {
                string[] newProduct = Console.ReadLine().Split(",");

                prod = new Product(newProduct[0], double.Parse(newProduct[1], CultureInfo.InvariantCulture));
                store.AddProduct(prod);
            }
            Console.WriteLine("Most Expensive:");
            Console.WriteLine(calculation.Max(store.ReturnAllItens()));
        }
    }
}
