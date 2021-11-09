using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Linq_4.Entities;

namespace Linq_4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> emp = new List<Employee>();

            Console.Write("Digite o Path: ");
            string path = Console.ReadLine();
            Console.Write("Enter the Salary: ");
            double salValue = double.Parse(Console.ReadLine());

            using(StreamReader sr = File.OpenText(path))
            {
                while(!sr.EndOfStream)
                {
                    string[] line = sr.ReadLine().Split(",");
                    string name = line[0];
                    string email = line[1];
                    double salary = double.Parse(line[2], CultureInfo.InvariantCulture);

                    emp.Add(new Employee(name, email, salary));
                }
            }

            var emails = emp.Where(e => e.Salary > salValue).OrderBy(e => e.Email).Select(e => e.Email);

            foreach(string email in emails)
                Console.WriteLine(email);

            var sum = emp.Where(e => e.Name[0] == 'M').Sum(e => e.Salary);
            Console.WriteLine("Sum of salary of people whose name starts with 'M': " + sum.ToString("F2", CultureInfo.InvariantCulture));
        }
    }
}