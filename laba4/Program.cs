using laba2.Accounts;
using laba2.Games.States;
using laba2.Handlers;
using laba3.DB;
using laba3.DB.Services;
using laba4.ConsoleManager;
using System.Xml;

namespace laba2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DbContext context = new();

            StatsService statsService = new(context);
            AccountService accountService = new(context);
            
            ConsoleManager manager = new();
            manager.Add(new AddPLayerCommand(accountService));
            manager.Add(new PlayGameCommand(accountService, statsService));
            manager.Add(new ShowPlayersCommad(accountService));
            manager.Add(new ShowAllStatsCommand(statsService));
            manager.Add(new ShowPlayerStatsByNameCommand(statsService, accountService));
            manager.Start();
        }
    }
}