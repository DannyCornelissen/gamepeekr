using Microsoft.EntityFrameworkCore;
namespace GamePeekrReviewManagementDAL
{
    public class GamekeeprDBContext: DbContext
    {
        public DbSet<ReviewEntity> Review { get; set; }

        public GamekeeprDBContext(DbContextOptions<GamekeeprDBContext> options) : base(options)
        {

        }
    }
}
