using laba2.Accounts.States;
using laba2.Games.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3.Handlers.Bilder
{
    public class StatsBilder : IStatsBilder
    {
        private Stats stats;

        public StatsBilder()
        {
            stats = new();
        }
        public void SetUserName(string WinnerName, string LoserName)
        {
            stats.WinnerName = WinnerName;
            stats.LoserName = LoserName;
        }
        public void SetUserType(AccountType WinnerAccType, AccountType LoserAccType)
        {
            stats.WinnerAccType = WinnerAccType;
            stats.LoserAccType = LoserAccType;
        }

        public void SetCurRating(int WinnerRating, int LoserRating)
        {
            stats.WinnerRating = WinnerRating;
            stats.LoserRating = LoserRating;
        }
        public void SetPrevRating(int PrevWinnerRating, int PrevLoserRating)
        {
            stats.PrevWinnerRating = PrevWinnerRating;
            stats.PrevLoserRating = PrevLoserRating;
        }

        public void SetGeneralValues(GameType gameType, int GameID)
        {
            stats.GameType = gameType;
            stats.GameID = GameID;
        }

        public Stats Bild()
        {
            return stats;
        }
    }
}
