using laba3.DB.Entity;

namespace laba3.DB.Repository.Base
{
    public interface IStatsRepository
    {
        public void Create(StatsEntity game);
        public IEnumerable<StatsEntity> Read();

        public void Update(StatsEntity game);

        public void Delete(int ID);

    }
}
