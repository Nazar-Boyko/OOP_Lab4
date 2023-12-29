using laba2.Accounts;
using laba2.Games;
using laba2.Games.States;
using laba2.Handlers;
using laba3.DB.Services;
using laba4.ConsoleManager.Base;

namespace laba4.ConsoleManager
{
    public class PlayGameCommand : ICommand
    {
        AccountService accService;
        StatsService statsService;
        public PlayGameCommand(AccountService accService, StatsService statsService)
        {
            this.accService = accService;
            this.statsService = statsService;
        }
        public void Execute()
        {
            GameFactory factory = new();

            var type = GetGameType();
            var game = factory.CreateGame(type);

            var players = GetPlayers();

            var player1 = players[0];
            var player2 = players[1];

            game.Play(player1, player2, statsService, accService);

            NextActions(player1.UserName, player2.UserName);
        }

        public string GetCommandInfo()
        {
            return "PLay game";
        }

        private GameType GetGameType()
        {
            while (true)
            {
                Console.Clear();
                Console.Write(
                    "\nGame types:\n" +
                    "\t1 - Clasic\n" +
                    "\t2 - Training\n" +
                    "\t3 - Crazy\n" +
                    "Select the type of game: "
                );
                var answer = Console.ReadLine();

                if (answer == "1") return GameType.Clasic;
                else if (answer == "2") return GameType.Training;
                else if (answer == "3") return GameType.Crazy;
                else Clear("Unknown command, try again!", 2000);
            }
        }

        private List<BaseAccount> GetPlayers()
        {
            var players = accService.ReadAccounts();
            List<BaseAccount> two_players = new();

            string players_name = string.Join("  --  ", players
                                        .Select(player => player.UserName));

            while (true)
            {
                var username = ChoiceUser(1, players_name);
                var user = players.FirstOrDefault(player => player.UserName == username);

                if (user != null)
                {
                    two_players.Add(user);
                    Clear("", 50);
                    break;
                }
                else Clear("User doesn't exist, try again", 2000);
            }
            while (true)
            {
                var username = ChoiceUser(2, players_name);
                var player = players.FirstOrDefault(plr => plr.UserName == username);

                if (player != null && two_players[0].UserName != player.UserName)
                {
                    two_players.Add(player);
                    Clear("", 50);
                    break;
                }
                else Clear("User doesn't exist or you choice this user, try again", 2000);
            }

            return two_players;
        }

        private void NextActions(string plrName1, string plrName2)
        {
            while (true)
            {
                Console.Clear();
                ShowStats(plrName1, plrName2);
                Console.WriteLine("What will we do next?");
                Console.Write(
                    "\t1 - Play another game\n" +
                    "\t2 - Back to lobby\n" +
                    "Chioce an actions: "
                    );
                var answer = Console.ReadLine();

                if (answer == "1") { Execute(); Clear("", 50); break; }
                else if (answer == "2") { Clear("", 50); break; }
                else Clear("Invalid chioce, try again", 2000);
            }
        }

        private string ChoiceUser(int number, string players_name)
        {
            Clear("", 50);
            Console.WriteLine("\n///  All players  \\\\\\");
            Console.WriteLine(players_name);
            Console.Write($"Choice player №{number} by his name: ");
            var username = Console.ReadLine();
            return username;
        }

        private void ShowStats(string plrName1, string plrName2)
        {
            Console.WriteLine($"\n\t\t\t\tGame information for {plrName1} and {plrName2}");
            var stat = statsService.ReadGames();
            int lastindex = stat.Count - 1;
            var lastgame = ShowInfo.GetStatsforLastGame(stat[lastindex]);
            Console.WriteLine(lastgame);

        }


        private void Clear(string text, int time)
        {
            Console.Write(text);
            Thread.Sleep(time);
            Console.Clear();
        }

    }
}
