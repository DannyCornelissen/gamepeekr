using GamePeekrEntityLayer;
using Microsoft.EntityFrameworkCore;


namespace GamePeekrReviewManagementDAL
{
    public class GamePeekrDBContext: DbContext
    {
        public DbSet<ReviewEntity> Review { get; set; }

        public GamePeekrDBContext(DbContextOptions<GamePeekrDBContext> options) : base(options)
        {

        }
    }
}
