using GamePeekrEntities;
using Microsoft.EntityFrameworkCore;


namespace GamePeekrReviewManagementDAL
{
    public class GamePeekrDBContext: DbContext
    {
        public DbSet<ReviewEntity> Review { get; set; }
        public DbSet<UserEntity> User { get; set; }

        public GamePeekrDBContext(DbContextOptions<GamePeekrDBContext> options) : base(options)
        {
            ModelBuilder modelBuilder = new ModelBuilder();
            modelBuilder.Entity<UserEntity>().HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.userId);
        }
    }
}
