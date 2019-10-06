using System;

namespace Task002
{
    class View
    {
        private Data _data;

        public View(Data data)
        {
            _data = data;
        }
        public void ShowData()
        {
            Console.WriteLine("Accounts / Amount");
            foreach (Account acc in _data.GetAccounts())
            {
                Console.WriteLine($"{acc.Name} / {acc.Amount}");
            }

            Console.WriteLine();
            Console.WriteLine("Commands:");
            Console.WriteLine("  Create <Account name> <Amount>");
            Console.WriteLine("  Transaction <Account name from> <Account name to> <Amount>");
            Console.WriteLine("  Close <Account name>");
        }
        public string[] GetCommand()
        {
            string[] strCommand = Console.ReadLine().ToLower().Split();
            switch (strCommand[0])
            {
                case "create":
                    
                    //strCommand[1], Convert.ToDouble(strCommand[2])
                    break;
            }

            return strCommand;
        }
    }
}
