using System;

namespace Task002
{
    class Account
    {
        public string Name { get; private set; }
        public double Amount { get; private set; }

        public Account(string name, double amount = 0)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            Name = name;
            Amount = amount;
        }

        public void Transaction(double sum)
        {
            Amount += sum;
        }
    }
}
