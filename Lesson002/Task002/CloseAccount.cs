using System;

namespace Task002
{
    class CloseAccount : Command
    {
        private string _accountName;
        private double _amount;
        private Data _data;
        public CloseAccount(string[] parameters, Data data)
        {
            if (parameters.Length > 2)
            {
                throw new ArgumentException("Неверное количество параметров команды.");
            }

            _data = data;
            _accountName = parameters[1];
            _amount = _data.GetAccountAmountByName(_accountName);
            _data.CloseAccount(_accountName);
        }

        public override void Undo()
        {
            _data.AddAccount(_accountName, _amount);
        }
    }
}
