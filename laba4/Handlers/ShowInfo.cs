using laba2.Accounts;
using laba2.Games.States;

namespace laba2.Handlers
{
    public class ShowInfo
    {
        public static string GetStats(List<Stats> History)
        {
            return GetStatsString(History);
        }

        public static string GetStatsforLastGame(Stats stats)
        {
            return GetStatsString(new List<Stats> { stats });
        }

        private static string GetStatsString(List<Stats> History)
        {
            string result = "*------------------------------------------------------------------------------------------------*\n"
                          + "| ID  |  GameType  | Winner   <->     Type |    Rating    | Loser    <->     Type |    Rating    |\n"
                          + "*------------------------------------------------------------------------------------------------*\n";

            foreach (var game in History)
            {
                result +=
                $"| {game.GameID,-3} | {game.GameType,-11}" +
                $"| {game.WinnerName,-10} {game.WinnerAccType,10} " +
                $"| {game.PrevWinnerRating,-4} -> {game.WinnerRating,4} " +
                $"| {game.LoserName,-10} {game.LoserAccType,10} " +
                $"| {game.PrevLoserRating,-4} -> {game.LoserRating,4} |\n";
            }
            result += "*------------------------------------------------------------------------------------------------*\n";
            return result;
        }


        public static string GetAccount(List<BaseAccount> accounts)
        {
            string result = "-------------------------------------\n" +
                            "|  UserName  |  Game Type  | Rating |\n" +
                            "-------------------------------------\n";
            foreach (var acc in accounts)
            {
                result += $"| {acc.UserName,-10} |  {acc.Type,-9}  | {acc.Rating,-6} |\n";

            }

            result += "-------------------------------------";

            return result;
        }
    }

}
