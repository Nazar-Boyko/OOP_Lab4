using laba3.DB.Entity;
using laba3.DB.Repository.Base;

namespace laba3.DB.Repository
{
    public class StatsRepository : IStatsRepository
    {
        private DbContext context;

        public StatsRepository(DbContext context)
        {
            this.context = context;
        }
        public void Create(StatsEntity game)
        {
            context.Games.Add(game);
        }

        public void Delete(int ID)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StatsEntity> Read()
        {
            return context.Games;
        }

        public void Update(StatsEntity game)
        {
            throw new NotImplementedException();
        }
    }
}
