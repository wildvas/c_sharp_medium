using System;
using System.Collections.Generic;
using System.Linq;

namespace Task002
{
    class Data
    {
        private List<Account> _accounts;

        public Data()
        {
            _accounts = new List<Account>();
        }

        public void AddAccount(string name, double sum)
        {
            if(_accounts.FirstOrDefault(a => a.Name == name) != null)
            {
                throw new ArgumentException($"Счет \"{name}\" уже существует");
            }
            _accounts.Add(new Account(name, sum));
        }

        public void DoTransaction(Account accFrom, Account accTo, double Sum)
        {
            accFrom.Transaction(-Sum);
            accTo.Transaction(Sum);
        }

        public void CloseAccount(string name)
        {
            Account accToRemove = _accounts.FirstOrDefault(a => a.Name == name);
            if (accToRemove == null)
            {
                throw new ArgumentException($"Счет \"{name}\" не существует");
            }

            _accounts.Remove(accToRemove);
        }

        public List<Account> GetAccounts()
        {
            return _accounts;
        }
    }
}
