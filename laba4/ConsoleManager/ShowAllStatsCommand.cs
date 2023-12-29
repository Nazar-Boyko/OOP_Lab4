using laba2.Handlers;
using laba3.DB.Services;
using laba4.ConsoleManager.Base;

namespace laba4.ConsoleManager
{
    public class ShowAllStatsCommand : ICommand
    {
        StatsService statsService;
        public ShowAllStatsCommand(StatsService statsService)
        {
            this.statsService = statsService;
        }
        public void Execute()
        {
            while (true)
            {
                Console.Clear();
                var players_stats = statsService.ReadGames();
                Console.Clear();
                if (players_stats.Any())
                {
                    Console.WriteLine($"\n\t\t\t\t\tAll game stats");
                    Console.WriteLine(ShowInfo.GetStats(players_stats));
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
            return "View all statistics";
        }

        private void NextActions()
        {
            Console.Write("\nTo return to the lobby, enter any character or press \"Enter\": ");
            Console.ReadLine();
            Console.Clear();

        }
       
    }
}
