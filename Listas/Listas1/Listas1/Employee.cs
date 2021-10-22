using System;
using System.Collections.Generic;

namespace ExFixaçaoListas
{
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; private set; }

        public Employee(int id, string name, double salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }

        public void IncreaseSalary(double percentage)
        {
            double percentage_aux = percentage / 100;
            Salary += Salary * percentage_aux;
        }

        public override string ToString()
        {
            return Id
                   + " ,"
                   + Name
                   + " ,"
                   + Salary;
        }
    }
}
