namespace Zafaran.WareHouse.Infrastructure
{
    public class BaseRepository
    {
        protected AppDbContext DbContext { get; set; }

        public BaseRepository(AppDbContext dbContext)
        {
            DbContext = dbContext;
        }
    }
}