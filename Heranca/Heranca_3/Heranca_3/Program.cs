using System;
using System.Globalization;
using System.Collections.Generic;
using Heranca_3.Entities;

namespace Heranca_3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TaxPayer> list = new List<TaxPayer>();
            double sum = 0;

            Console.Write("Enter the number of tax payers:");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Tax payer #{i} data:");
                Console.Write("Individual or company (i/c): ");
                char ch = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Anual Income: ");
                double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (ch == 'i')
                {
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new IndividualPayer(name, anualIncome, healthExpenditures));
                }
                else
                {
                    Console.Write("Number of employees: ");
                    int numberEmployees = int.Parse(Console.ReadLine());
                    list.Add(new CompanyPayer(name, anualIncome, numberEmployees));
                }
            }
            Console.WriteLine();
            Console.WriteLine("TAXES PAID: ");
            foreach (TaxPayer payer in list)
            {
                Console.WriteLine(payer.Name + ": $" + payer.TaxPaid().ToString("F2", CultureInfo.InvariantCulture));
                sum += payer.TaxPaid();
            }
            Console.WriteLine("TOTAL TAXES: $" + sum);
        }
    }
}