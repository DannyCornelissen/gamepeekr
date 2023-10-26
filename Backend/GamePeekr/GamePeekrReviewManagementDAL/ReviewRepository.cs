using GamePeekrEntityLayer;
using GamepeekrReviewManagement;
using Microsoft.Extensions.Logging;


namespace GamePeekrReviewManagementDAL
{
    public class ReviewRepository:IReview
    {
        private readonly GamekeeprDBContext _context;
        private readonly ILogger<ReviewRepository> _logger;

        public ReviewRepository(GamekeeprDBContext context, ILogger<ReviewRepository> logger)
        {
            _context = context;
            _logger = logger;


        }
        public List<ReviewEntity> GetReviews()
        {
            try
            {
                List<ReviewEntity> reviews = _context.Review.ToList();

                return reviews;
            }
            catch (Exception sqlE )
            {
                _logger.LogError(sqlE, "An error occurred while getting reviews.");
                throw ;
            }
        }

        public ReviewEntity GetReviewById(Guid id)
        {
            try
            {
                ReviewEntity review = _context.Review.Where(r => r.Id == id).First();

                return review;
            }
            catch (Exception sqlE)
            {
                _logger.LogError(sqlE, "An error occurred while getting the review.");
                throw;
            }
        }

    }
}