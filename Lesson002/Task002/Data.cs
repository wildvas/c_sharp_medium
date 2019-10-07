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

        public void DoTransaction(string accFromName, string accToName, double Sum)
        {
            Account accFrom = _accounts.FirstOrDefault(a => a.Name == accFromName);
            if (accFrom == null)
            {
                throw new ArgumentException($"Счет \"{accFromName}\" не существует");
            }

            Account accTo = _accounts.FirstOrDefault(a => a.Name == accToName);
            if (accTo == null)
            {
                throw new ArgumentException($"Счет \"{accToName}\" не существует");
            }

            if(accFrom.Amount < Sum)
            {
                throw new ArgumentException($"Недостаточно средств на счете отправителе");
            }

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

        public double GetAccountAmountByName(string name)
        {
            Account acc = _accounts.FirstOrDefault(a => a.Name == name);
            if (acc == null)
            {
                throw new ArgumentException($"Счет \"{name}\" не существует");
            }

            return acc.Amount;
        }

        public IReadOnlyList<Account> GetAccounts()
        {
            return _accounts;
        }
    }
}
