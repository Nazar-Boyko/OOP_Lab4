using laba2.Games.States;
using laba2.Handlers;
using laba3.DB.Entity;
using laba3.DB.Repository;
using laba3.DB.Repository.Base;
using laba3.DB.Services.Base;
using laba3.Handlers.Bilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace laba3.DB.Services
{
    public class StatsService : IStatsService
    {
        private IStatsRepository statsRepository;

        public StatsService(DbContext context)
        {
            statsRepository = new StatsRepository(context);
        }
        public void CreateGame(Stats stats)
        {
            StatsEntity gameStatsEntity = SetValues(stats);
            statsRepository.Create(gameStatsEntity);
        }

        public List<Stats> ReadGames()
        {
            return statsRepository.Read().Select(game => Map(game)).ToList();
        }

        public List<Stats> ReadGamesByPlayerName(string PlayerName)
        {
            var gameStatsEntities = statsRepository
                                        .Read()
                                        .Where(game => game.WinnerName == PlayerName || game.LoserName == PlayerName)
                                        .ToList();

            return gameStatsEntities.Select(Map).ToList();
        }

        public Stats Map(StatsEntity stats)
        {
            StatsBilder bilder = new();
            bilder.SetUserName(stats.WinnerName, stats.LoserName);
            bilder.SetUserType(stats.WinnerAccType, stats.LoserAccType);
            bilder.SetCurRating(stats.WinnerRating, stats.LoserRating);
            bilder.SetPrevRating(stats.PrevWinnerRating, stats.PrevLoserRating);
            bilder.SetGeneralValues(stats.GameType, stats.GameID);
            return bilder.Bild();
        }

        private StatsEntity SetValues(Stats stats)
        {
            return new()
            {
                WinnerName = stats.WinnerName,
                LoserName = stats.LoserName,
                WinnerAccType = stats.WinnerAccType,
                LoserAccType = stats.LoserAccType,
                WinnerRating = stats.WinnerRating,
                LoserRating = stats.LoserRating,
                PrevWinnerRating = stats.PrevWinnerRating,
                PrevLoserRating = stats.PrevLoserRating,
                GameID = stats.GameID,
                GameType = stats.GameType
            };

            
        }
    }
}
