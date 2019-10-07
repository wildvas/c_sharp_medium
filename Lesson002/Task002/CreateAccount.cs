using System;

namespace Task002
{
    partial class Program
    {
        class CreateAccount : Command
        {
            private string _accountName;
            private double _accountAmount;
            private Data _data;
            public CreateAccount(string[] parameters, Data data)
            {
                if(parameters.Length < 2 || parameters.Length > 3)
                {
                    throw new ArgumentException("Неверное количество параметров команды.");
                }

                _data = data;
                _accountName = parameters[1];
                _accountAmount = 0;
                if (parameters.Length == 3)
                {
                    _accountAmount = double.Parse(parameters[2]);
                }

                _data.AddAccount(_accountName, _accountAmount);
            }

            public override void Undo()
            {
                _data.CloseAccount(_accountName);
            }
        }
    }
}
