using System;
using System.Globalization;
using Exceptions_1.Entities;
using Exceptions_1.Entities.Exceptions;

namespace Exceptions_1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Account account;

                Console.WriteLine("Enter account data");
                Console.Write("Number: ");
                int number = int.Parse(Console.ReadLine());
                Console.Write("Holder: ");
                string holder = Console.ReadLine();
                Console.Write("Initial Balance: $");
                double initialBalance = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("WithDraw limit: ");
                double withDrawLimit = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                account = new Account(number, holder, initialBalance, withDrawLimit);

                Console.WriteLine();
                Console.Write("Enter amount for withdraw: ");
                double amount = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                account.WithDraw(amount);
                Console.WriteLine("New Balance: " + account);
            }
            catch(DomainException e)
            { 
                Console.WriteLine("Withdraw error: " + e.Message);
            }
            catch(FormatException e)
            {
                Console.WriteLine("Format error: " + e.Message);
            }
        }
    }
}
