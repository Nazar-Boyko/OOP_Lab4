using laba2.Games.States;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba3.DB.Services.Base
{
    public interface IStatsService
    {
        public void CreateGame(Stats stats);
        public List<Stats> ReadGames();
        public List<Stats> ReadGamesByPlayerName(string PlayerName);

    }
}
