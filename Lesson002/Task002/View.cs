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

        public void Start()
        {
            Console.WriteLine("Введите help для справки.");
        }

        public void ShowHelp()
        {
            Console.WriteLine("Команды:");
            Console.WriteLine("  Create <AccountName> <Amount> - Создать новый счет.\n    <AccountName> - имя нового счета, без пробелов\n    <Amount> - сумма на счете, по умолчанию 0.");
            Console.WriteLine("  Transaction <AccountNameFrom> <AccountNameTo> <Amount> - Перевод между счетами.\n    <AccountNameFrom> - имя счета отправителя\n    <AccountNameTo> - имя счета получателя\n    <Amount> - сумма перевода");
            Console.WriteLine("  Close <AccountName> - закрытие счета\n    <AccountName> - имя закрываемого счета");
            Console.WriteLine("  Show - показать список счетов");
            Console.WriteLine("  Undo - Отмена предыдущей операции");
            Console.WriteLine("  Exit - Выход из программы");
            Console.WriteLine("  Help - эта справка");
        }

        public void ShowData()
        {
            Console.WriteLine("Accounts / Amount");
            foreach (Account acc in _data.GetAccounts())
            {
                Console.WriteLine($"{acc.Name} / {acc.Amount}");
            }

            Console.WriteLine();
            
        }

        public void OperationComplite()
        {
            Console.WriteLine("Операция выполнена");
        }

        public void ErrorMEssage(string msg)
        {
            Console.WriteLine("Ошибка при выполнении операции.");
            Console.WriteLine(msg);
        }
        public string[] GetCommand()
        {
            string[] strCommand = Console.ReadLine().ToLower().Split();
            return strCommand;
        }
    }
}
