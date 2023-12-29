using laba2.Accounts;
using laba2.Handlers;
using laba3.DB.Services;
using laba4.ConsoleManager.Base;

namespace laba4.ConsoleManager
{
    public class ShowPlayerStatsByNameCommand : ICommand
    {
        StatsService statsService;
        AccountService accService;
        public ShowPlayerStatsByNameCommand(StatsService statsService, AccountService accService)
        {
            this.statsService = statsService;
            this.accService = accService;
        }
        public void Execute()
        {
            while (true)
            {
                Console.Clear();
                ShowPlayers();
                Console.Write("\nPlease input user name: ");
                var username = Console.ReadLine();
                var player_stats = statsService.ReadGamesByPlayerName(username);
                Console.Clear();
                if (player_stats.Any())
                {
                    Console.WriteLine($"All game for {username}");
                    Console.WriteLine(ShowInfo.GetStats(player_stats));
                    NextActions();
                    break;
                }
                else
                {
                    Console.WriteLine("No such user exists.");
                    NextActions();
                    break;
                }
            }
        }

        public string GetCommandInfo()
        {
            return "View player statistics by name";
        }

        private void NextActions()
        {
            while (true)
            {
                Console.WriteLine("What will we do next?");
                Console.Write(
                    "\t1 - Try again\n" +
                    "\t2 - Back to lobby\n" +
                    "Choose an action: "
                );

                var answer = Console.ReadLine();

                if (answer == "1") { Clear("", 50); Execute(); break; }
                else if (answer == "2") { Clear("", 50); break; }
                else { Clear("Invalid chioce, try again", 2000); }
            }

        }

        private void ShowPlayers()
        {
            var players = accService.ReadAccounts();
            string players_name = string.Join("  --  ", players
                                        .Select(player => player.UserName));

            Console.WriteLine("\n\t\t///  All players  \\\\\\");
            Console.WriteLine(players_name);
        }

        private void Clear(string text, int time)
        {
            Console.Write(text);
            Thread.Sleep(time);
            Console.Clear();
        }


    }
}
