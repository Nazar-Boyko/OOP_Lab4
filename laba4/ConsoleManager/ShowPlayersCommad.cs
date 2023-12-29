using laba2.Handlers;
using laba3.DB.Services;
using laba4.ConsoleManager.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba4.ConsoleManager
{
    public class ShowPlayersCommad : ICommand
    {
        AccountService accService;
        public ShowPlayersCommad(AccountService accService)
        {
            this.accService = accService;
        }
        public void Execute()
        {
            var accounts = accService.ReadAccounts();
            Console.Clear();
            Console.WriteLine(ShowInfo.GetAccount(accounts));
            Console.Write("\nTo return to the lobby, enter any character or press \"Enter\": ");
            Console.ReadLine();
            Console.Clear();
        }

        public string GetCommandInfo()
        {
            return "View players";
        }


    }
}
