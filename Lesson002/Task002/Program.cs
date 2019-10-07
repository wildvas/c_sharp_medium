using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task002
{

    partial class Program
    {
        static Data data;
        static View view;
        static List<Command> commands;

        static void ProcessCommand(string[] newCommand, ref bool needExit)
        {
            switch (newCommand[0])
            {
                case "help":
                    view.ShowHelp();
                    break;
                case "show":
                    view.ShowData();
                    break;
                case "create":
                    commands.Add(new CreateAccount(newCommand, data));
                    view.OperationComplite();
                    break;
                case "transaction":
                    commands.Add(new Transaction(newCommand, data));
                    view.OperationComplite();
                    break;
                case "close":
                    commands.Add(new CloseAccount(newCommand, data));
                    view.OperationComplite();
                    break;
                case "exit":
                    needExit = true;
                    break;
                case "undo":
                    if (commands.Count > 0)
                    {
                        Command cmd = commands[commands.Count - 1];
                        cmd.Undo();
                        commands.Remove(cmd);
                    }
                    view.OperationComplite();
                    break;
            }
        }

        static void Main(string[] args)
        {
            data = new Data();
            view = new View(data);
            commands = new List<Command>();

            bool needExit = false;

            view.Start();
            while (!needExit)
            {
                try
                {
                    ProcessCommand(view.GetCommand(), ref needExit);
                }
                catch (Exception e)
                {
                    view.ErrorMEssage(e.Message);
                }
            }
        }
    }
}
