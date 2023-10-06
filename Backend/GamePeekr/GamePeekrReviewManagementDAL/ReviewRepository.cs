using GamepeekrReviewManagement;


namespace GamePeekrReviewManagementDAL
{
    public class ReviewRepository:IReview
    {
        private readonly GamekeeprDBContext _context;
  
        public ReviewRepository(GamekeeprDBContext context)
        {
            _context = context;

        }
        public List<IReviewEntity> GetReviews()
        {
            List<IReviewEntity> reviews = _context.Review
                .Select(r => (IReviewEntity)r)
                .ToList();

            return reviews;
        }

        public IReviewEntity GetReviewById(Guid id)
        {
            IReviewEntity review = _context.Review.Select(r => (IReviewEntity)r).Where(r => r.Id == id).First();

            return review;
        }

    }
}