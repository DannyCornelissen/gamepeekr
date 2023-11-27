using GamePeekrEntities;
using GamepeekrReviewManagement.Interfaces;
using Microsoft.Extensions.Logging;

namespace GamePeekrReviewManagementDAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GamePeekrDBContext _context;
        private readonly ILogger<ReviewRepository> _logger;

        public UserRepository(GamePeekrDBContext context, ILogger<ReviewRepository> logger)
        {
            _context = context;
            _logger = logger;
        }


        public UserEntity GetUserById(Guid id)
        {
            try
            {
                UserEntity user = _context.User.Where(r => r.Id == id).First();

                return user;
            }
            catch (Exception sqlE)
            {
                _logger.LogError(sqlE, "An error occurred while getting the review.");
                throw;
            }
        }
    }
}
