using System;
using Exceptions_1.Entities.Exceptions;


namespace Exceptions_1.Entities
{
    class Account
    {
        public int Number { get; set; }
        public string Holder { get; set; }
        public double Balance { get; private set; }
        public double WithDrawLimit { get; set; }

        public Account()
        {
        }

        public Account(int number, string holder, double balance, double withDrawLimit)
        {
            Number = number;
            Holder = holder;
            Balance = balance;
            WithDrawLimit = withDrawLimit;
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }

        public void WithDraw(double amount)
        {
            if (amount > WithDrawLimit)
                throw new DomainException("The amount exceeds withdraw limit");
            if(amount > Balance ) 
                throw new DomainException("Not enough balance");

            Balance -= amount;
        }

        public override string ToString()
        {
            return "New Balance: $"
                + Balance;
        }
    }
}
