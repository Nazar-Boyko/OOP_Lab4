using laba2.Handlers;
using laba3.DB.Services;
using laba4.ConsoleManager.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace laba4.ConsoleManager
{
    public class ConsoleManager
    {
        public List<ICommand> Commands { get; } = new();

        public void Add(ICommand command)
        {
            Commands.Add(command);
        }

        public void Start()
        {
            while (true)
            {
                Console.Write(ShowLobby());

                var input = Console.ReadLine();

                if (int.TryParse(input, out int res) && res == Commands.Count+1)
                {
                    break;
                }
                else if (int.TryParse(input, out int result) && result <= Commands.Count)
                {
                    Commands[result-1].Execute();
                }
                else
                {
                    Console.WriteLine("Invalid choice, try again!");
                    Thread.Sleep(2000);
                    Console.Clear();

                }
            }

            Console.Clear();
            Console.WriteLine(EndMessage());
        }


        private string ShowLobby()
        {
            string result = "\nWelcome to the WORLD`S BEST SUPER DUPER UNREAL GAME (limited ULTRA version)\n\n" +
                            "In the game you can... \n";

            for (int i = 0; i < Commands.Count; i++)
            {
                result += $"\t{i + 1} - {Commands[i].GetCommandInfo()}\n";
            }
            result += $"\t{Commands.Count+1} - Exit game\n" +
                      "Choose an action: ";
            return result;
        }

        private string EndMessage()
        {
            return "\n\n" +
                     "\t\t████████████████████████████████████████████████████\n" +
                     "\t\t█    █    █    █    █████ ███ █ █    █ ██ ████ █ █ █\n" +
                     "\t\t█ ████ ██ █ ██ █ ██  ████ ███ █ █ ██ █ █ █████ █ █ █\n" +
                     "\t\t█ █  █ ██ █ ██ █ ██  ████ ███ █ █ ████  ██████ █ █ █\n" +
                     "\t\t█ ██ █ ██ █ ██ █ ██  ████ ███ █ █ ██ █ █ ███████████\n" +
                     "\t\t█    █    █    █    █████   █   █    █ ██ ████ █ █ █\n" +
                     "\t\t████████████████████████████████████████████████████\n";
        }

    }
}
