using System;

namespace Task002
{
    class Transaction : Command
    {
        private string _accountFromName;
        private string _accountToName;
        private double _amount;
        private Data _data;
        public Transaction(string[] parameters, Data data)
        {
            if (parameters.Length != 4)
            {
                throw new ArgumentException("Неверное количество параметров команды.");
            }

            _data = data;
            _accountFromName = parameters[1];
            _accountToName = parameters[2];
            _amount = double.Parse(parameters[3]);

            _data.DoTransaction(_accountFromName, _accountToName, _amount);
        }

        public override void Undo()
        {
            _data.DoTransaction(_accountFromName, _accountToName, -_amount);
        }
    }
}
