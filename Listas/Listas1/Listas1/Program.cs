using System;
using System.Globalization;
using System.Collections.Generic;

namespace ExFixaçaoListas
{
    class Program
    {
        static void Main(string[] args)
        {


            Console.Write("How many employees will be registred?: ");
            int qtd = int.Parse(Console.ReadLine());

            if (qtd == 0)
            {
                Console.WriteLine("Obrigado");
                return;
            }

            List<Employee> list = new List<Employee>();

            for (int i = 0; i < qtd; i++)
            {
                Console.WriteLine("Employees #{0}:", (i + 1));

                Console.Write("Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Salary: ");
                double salary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Employee emp = list.Find(x => x.Id == id);

                if (emp != null)
                {
                    Console.WriteLine("O ID cadastrado já existe, Tente outro.");
                    i--;
                }
                else
                {
                    list.Add(new Employee(id, name, salary));
                }
                Console.WriteLine();
            }

            Console.Write("Enter the employee id that will have salary increase : ");
            int id_aux = int.Parse(Console.ReadLine());
        
            Employee emp_aux = list.Find(x => x.Id == id_aux);

            if(emp_aux != null)
            {
                Console.Write("Enter the percentage: ");
                double percent = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                emp_aux.IncreaseSalary(percent);
            }
            else
            {
                Console.WriteLine("This id does not exist!");
            }

            Console.WriteLine();
            Console.WriteLine("Updated list of emloyees");
            foreach (Employee obj in list)
                Console.WriteLine(obj);
        }
    }
}
