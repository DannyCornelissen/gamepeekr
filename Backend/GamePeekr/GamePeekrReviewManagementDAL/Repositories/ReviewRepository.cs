using GamePeekrEntities;
using GamepeekrReviewManagement.Interfaces;
using Microsoft.Extensions.Logging;


namespace GamePeekrReviewManagementDAL.Repositories
{
    public class ReviewRepository : IreviewRepository
    {
        private readonly GamePeekrDBContext _context;
        private readonly ILogger<ReviewRepository> _logger;

        public ReviewRepository(GamePeekrDBContext context, ILogger<ReviewRepository> logger)
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
            catch (Exception sqlE)
            {
                _logger.LogError(sqlE, "An error occurred while getting reviews.");
                throw;
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

        public void AddReview(ReviewEntity reviewEntity)
        {
            try
            {
                _context.Review.Add(reviewEntity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while adding the review.");
                throw;
            }

        }
    }
}